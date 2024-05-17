using System.Configuration;
using BCStripeSync;
using BCStripeSync.APIServiceExtensions;
using BCStripeSync.Connectors;
using D365BCConnectorAPIGear;
using Serilog;
using Stripe;
using Customer = Stripe.Customer;
using CustomerService = D365BCConnectorAPIGear.CustomerService;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/StripeSync.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


var bcClientId = ConfigurationManager.AppSettings["bcClientId"];
var bcClientSecret = ConfigurationManager.AppSettings["bcClientSecret"];
var bcTenantId = ConfigurationManager.AppSettings["bcTenantId"];
var bcCompanyId = ConfigurationManager.AppSettings["bcCompanyId"];
var stripeSecretKey = ConfigurationManager.AppSettings["stripeSecretKey"];
var customerNoToSkipString = ConfigurationManager.AppSettings["customerNoToSkip"];
var customerNoToSkip = new List<string>(customerNoToSkipString.Split(','));


var bcSalesQuoteExtendedService = new SalesQuoteHeaderService(bcClientId, bcClientSecret, bcTenantId, bcCompanyId);
var bcCustomerService = new CustomerService(bcClientId, bcClientSecret, bcTenantId, bcCompanyId);
var bcSalesQuoteLineService = new SalesQuoteLineService(bcClientId, bcClientSecret, bcTenantId, bcCompanyId);


var stripeService = new StripeConnector(stripeSecretKey);

var stripeProductManager = new StripeProductManager(stripeService);

var mapperConfiguration = AutoMapperConfig.Configure();
var mapper = mapperConfiguration.CreateMapper();


////var autoBuilder = new Automation(bsService);
var quoteList = await bcSalesQuoteExtendedService.GetFilteredAsync("status",
    BusinessCentralService.FilterOperator.Equal,
    "Released") ?? throw new ArgumentNullException(
    "salesQuoteExtendedService.GetFilteredAsync(\"status\", BusinessCentralService.FilterOperator.Equal, \"Released\")");


// Process payments //
// The quote must have an invoice ID, not be paid, not have a payment ID, and be set to auto pay //
foreach (var q in quoteList.Value)
{
    var bcCustomerData = await bcCustomerService.GetByNumberAsync(q.SellToCustomerNo);

    if (bcCustomerData != null)
    {
        var customer = bcCustomerData.Value.FirstOrDefault();

        if (customer != null)
            if (customerNoToSkip.All(s => s != customer.No))
                if (!string.IsNullOrEmpty(q.StripeInvoiceId) && q.StripePaid == false &&
                    string.IsNullOrEmpty(q.StripePaymentId) && q.StripeAutoPay)
                {
                    var paymentResult = stripeService.ChargeInvoice(q.StripeInvoiceId);
                }
    }
}


foreach (var quoteHeader in quoteList.Value)
{
    // Take the quote header and find the customer record in Business Central
    var bcCustomerData = await bcCustomerService.GetByNumberAsync(quoteHeader.SellToCustomerNo);

    if (bcCustomerData != null)
    {
        var customer = bcCustomerData.Value.FirstOrDefault();

        if (string.IsNullOrEmpty(quoteHeader.StripeQuoteId))
            try
            {
                var customerId = quoteHeader.SellToCustomerNo;

                var WarrantyReplacement = false;

                if (bcCustomerData != null)
                    if (customerNoToSkip.All(s => s == customer.No))
                    {
                        WarrantyReplacement = true;
                        customerId = "WarrantyReplacement" + "-" + quoteHeader.No;
                    }


                // Todo: make this and  EnsureStripeCustomerAsync()
                var stripeCustomer = stripeService.GetCustomerByBcCustomerId(customerId);
                if (!stripeCustomer.Any())
                {
                    var stripeCustomerData = mapper.Map<Customer>(customer);

                    if (WarrantyReplacement) stripeCustomerData.Name = quoteHeader.ShipToName;

                    var customerResult = stripeService.CreateCustomer(stripeCustomerData, customerId);
                    Thread.Sleep(10000); // Stripe API takes a few seconds to update the customer //
                    stripeCustomer = stripeService.GetCustomerByBcCustomerId(customerId);
                    continue;
                }

                // Log the customer ID
                Log.Information($"Customer: {stripeCustomer.First().Id}");

                // Retrieve and filter the sales quote lines
                var lines = await bcSalesQuoteLineService.GetByQuoteIdAsync(quoteHeader.SystemId);
                var filteredLines = lines.Value.Where(x => x.LineType != "Comment").ToList();

                var quoteLines = new List<QuoteLineItemOptions>();

                foreach (var line in filteredLines)
                    if (!string.IsNullOrEmpty(line.LineObjectNumber))
                        try
                        {
                            var stripePrice = await stripeProductManager.SetUpProductAsync(line);
                            var quoteLineItem = new QuoteLineItemOptions
                            {
                                Price = stripePrice.Id,
                                Quantity = Convert.ToInt64(line.Quantity)
                            };
                            quoteLines.Add(quoteLineItem);
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, $"Error setting up product for line: {line.LineObjectNumber}");
                        }


                var newQuote = stripeService.CreateQuote(quoteHeader.No, stripeCustomer.First().Id, quoteLines);
                newQuote = stripeService.FinalizeQuote(newQuote.Id);
                newQuote = stripeService.GenerateInvoice(newQuote.Id);
                var stripeInvoice = stripeService.FinalizeInvoice(newQuote.InvoiceId);

                Log.Information($"Quote:{quoteHeader.No}");

                var updated = await bcSalesQuoteExtendedService.UpdateByNoAsync(quoteHeader.No,
                    new Dictionary<string, object>
                    {
                        { "stripeQuoteId", newQuote.Id },
                        { "stripeInvoiceId", stripeInvoice.Id },
                        { "stripeHostedInvoiceUrl", stripeInvoice.HostedInvoiceUrl }
                    }, quoteHeader.OdataEtag);

                Log.Information($"Quote:{quoteHeader.No}");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error: " + ex.Message);
            }
    }

    if (quoteHeader.StripePaid && !string.IsNullOrEmpty(quoteHeader.StripeInvoiceId))
    {
        var stripeInvoice = stripeService.GetInvoice(quoteHeader.StripeInvoiceId);


        if (stripeInvoice.Paid)
        {
            var updated = await bcSalesQuoteExtendedService.UpdateByNoAsync(quoteHeader.No,
                new Dictionary<string, object>
                {
                    { "stripePaid", stripeInvoice.Paid },
                    { "stripeInvoicePdf", stripeInvoice.InvoicePdf }
                }, quoteHeader.OdataEtag);
        }
    }

    Log.Information($"Quotes Synced: {quoteHeader.No}");
}