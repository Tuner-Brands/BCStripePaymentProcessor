using Stripe;

namespace BCStripeSync.Connectors;

public class StripeConnector
{
    public StripeConnector(string key)
    {
        Key = key;
        StripeConfiguration.ApiKey = Key; // Set the API key only once
    }

    public string Key { get; }


    public Invoice ChargeInvoice(string stripeInvoiceId)
    {
        var service = new InvoiceService();
        try
        {
            return service.Pay(stripeInvoiceId);
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            throw new InvalidOperationException("Failed to charge invoice.", ex);
        }
    }


    public Customer CreateCustomer(Customer customer, string dynamicsId)
    {
        var options = new CustomerCreateOptions
        {
            Description = customer.Description,
            Email = customer.Email,
            Metadata = new Dictionary<string, string> { { "dynamicsId", dynamicsId } },
            Name = customer.Name,
            Phone = customer.Phone,
            Address = new AddressOptions
            {
                City = customer.Address.City,
                Country = customer.Address.Country,
                Line1 = customer.Address.Line1,
                Line2 = customer.Address.Line2,
                PostalCode = customer.Address.PostalCode,
                State = customer.Address.State
            }
        };

        var service = new CustomerService();
        return service.Create(options);
    }


    public Price CreatePrice(double price, string stripeProductId)
    {
        var options = new PriceCreateOptions
        {
            Currency = "usd",
            Active = true,
            UnitAmount = Convert.ToInt64(Math.Round(price * 100)),
            Product = stripeProductId
        };

        var service = new PriceService();
        return service.Create(options);
    }


    public Quote CreateQuote(string dynamicsQuoteId, string stripeCustomerId, List<QuoteLineItemOptions> quoteLines)
    {
        if (string.IsNullOrWhiteSpace(stripeCustomerId))
            throw new ArgumentException("Customer ID cannot be null or whitespace.", nameof(stripeCustomerId));

        if (string.IsNullOrWhiteSpace(dynamicsQuoteId))
            throw new ArgumentException("Dynamics Quote ID cannot be null or whitespace.", nameof(dynamicsQuoteId));

        if (quoteLines == null || !quoteLines.Any())
            throw new ArgumentException("Quote lines cannot be null or empty.", nameof(quoteLines));

        var options = new QuoteCreateOptions
        {
            Customer = stripeCustomerId,
            LineItems = quoteLines,
            Metadata = new Dictionary<string, string> { { "dynamicsId", dynamicsQuoteId } }
        };

        var service = new QuoteService();
        try
        {
            return service.Create(options);
        }
        catch (StripeException ex)
        {
            // Log the exception or handle it as required
            throw new InvalidOperationException("Failed to create quote.", ex);
        }
    }

    public Price DeletePrices(string stripPriceId)
    {
        if (string.IsNullOrWhiteSpace(stripPriceId))
            throw new ArgumentException("Price ID cannot be null or whitespace.", nameof(stripPriceId));

        var service = new PriceService();
        var options = new PriceUpdateOptions { Active = false };

        try
        {
            return service.Update(stripPriceId, options);
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to delete/update price.", ex);
        }
    }


    public void DeleteProduct(string stripProductId)
    {
        if (string.IsNullOrWhiteSpace(stripProductId))
            throw new ArgumentException("Product ID cannot be null or whitespace.", nameof(stripProductId));

        var productService = new ProductService();
        var priceService = new PriceService();

        try
        {
            var associatedPriceList = priceService.List(new PriceListOptions { Product = stripProductId });

            if (!associatedPriceList.Any())
            {
                productService.Delete(stripProductId);
            }
            else
            {
                var productToUpdate = productService.Get(stripProductId);
                productToUpdate.Active = false;
                var updateOptions = new ProductUpdateOptions { Active = false };
                productService.Update(stripProductId, updateOptions);
            }
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to delete or deactivate product.", ex);
        }
    }

    public Invoice FinalizeInvoice(string stripeInvoiceId)
    {
        if (string.IsNullOrWhiteSpace(stripeInvoiceId))
            throw new ArgumentException("Invoice ID cannot be null or whitespace.", nameof(stripeInvoiceId));

        var service = new InvoiceService();
        try
        {
            return service.FinalizeInvoice(stripeInvoiceId, new InvoiceFinalizeOptions());
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to finalize invoice.", ex);
        }
    }


    public Quote FinalizeQuote(string stripeQuoteId)
    {
        if (string.IsNullOrWhiteSpace(stripeQuoteId))
            throw new ArgumentException("Quote ID cannot be null or whitespace.", nameof(stripeQuoteId));

        var service = new QuoteService();
        try
        {
            return service.FinalizeQuote(stripeQuoteId);
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to finalize quote.", ex);
        }
    }


    public Quote GenerateInvoice(string stripeQuoteId)
    {
        if (string.IsNullOrWhiteSpace(stripeQuoteId))
            throw new ArgumentException("Quote ID cannot be null or whitespace.", nameof(stripeQuoteId));

        var service = new QuoteService();
        try
        {
            return service.Accept(stripeQuoteId);
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to generate invoice from quote.", ex);
        }
    }

    public List<Customer> GetCustomerByBcCustomerId(string dynamicsId)
    {
        if (string.IsNullOrWhiteSpace(dynamicsId))
            throw new ArgumentException("Dynamics ID cannot be null or whitespace.", nameof(dynamicsId));

        var options = new CustomerSearchOptions
        {
            Query = $"metadata['dynamicsId']:'{dynamicsId}'"
        };

        var service = new CustomerService();
        try
        {
            return service.Search(options).ToList();
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to search customers by Dynamics ID.", ex);
        }
    }


    public Customer GetCustomerById(string stripeId)
    {
        if (string.IsNullOrWhiteSpace(stripeId))
            throw new ArgumentException("Stripe ID cannot be null or whitespace.", nameof(stripeId));

        var service = new CustomerService();
        try
        {
            return service.Get(stripeId);
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to retrieve customer.", ex);
        }
    }


    public PaymentMethod GetDefaultPayment(string stripeInvoiceId)
    {
        if (string.IsNullOrWhiteSpace(stripeInvoiceId))
            throw new ArgumentException("Invoice ID cannot be null or whitespace.", nameof(stripeInvoiceId));

        var invoiceService = new InvoiceService();
        var customerService = new CustomerService();
        try
        {
            var invoice = invoiceService.Get(stripeInvoiceId);
            var customer = customerService.Get(invoice.CustomerId);
            return customer.InvoiceSettings.DefaultPaymentMethod;
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to retrieve default payment method.", ex);
        }
    }


    public Invoice GetInvoice(string stripeInvoiceId)
    {
        if (string.IsNullOrWhiteSpace(stripeInvoiceId))
            throw new ArgumentException("Invoice ID cannot be null or whitespace.", nameof(stripeInvoiceId));

        var service = new InvoiceService();
        try
        {
            return service.Get(stripeInvoiceId);
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to retrieve invoice.", ex);
        }
    }


    public List<Price> GetPricesByProductId(string stripeId)
    {
        if (string.IsNullOrWhiteSpace(stripeId))
            throw new ArgumentException("Stripe ID cannot be null or whitespace.", nameof(stripeId));

        var service = new PriceService();
        var options = new PriceSearchOptions
        {
            Query = $"product:'{stripeId}'"
        };

        try
        {
            var searchResults = service.Search(options);
            return searchResults.ToList(); // Directly return the list, empty if no results
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to retrieve prices.", ex);
        }
    }


    public List<Product> GetProductsBySku(string sku, bool active = true)
    {
        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU cannot be null or whitespace.", nameof(sku));

        var service = new ProductService();
        var options = new ProductSearchOptions
        {
            Query = $"active:'{active}' and metadata['SKU']:'{sku}'"
        };

        try
        {
            var partData = service.Search(options);
            return partData.ToList(); // Directly return the list, empty if no results
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to retrieve products by SKU.", ex);
        }
    }


    public Product GetProductsByStripeId(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Stripe ID cannot be null or whitespace.", nameof(id));

        var service = new ProductService();
        try
        {
            return service.Get(id);
        }
        catch (StripeException ex)
        {
            throw new InvalidOperationException("Failed to retrieve product.", ex);
        }
    }


    public Product CreateNewProduct(Product prod)
    {
        StripeConfiguration.ApiKey = Key;
        var service = new ProductService();

        var saveProductOptions = new ProductCreateOptions();
        saveProductOptions.Active = prod.Active;
        //saveProductOptions. = prod.Attributes;
        //if (prod.Caption != string.Empty)
        //    saveProductOptions.Caption = prod.Caption;
        //saveProductOptions.DeactivateOn = prod.DeactivateOn;
        if (prod.Description != string.Empty)
            saveProductOptions.Description = prod.Description;
        saveProductOptions.Images = prod.Images;
        saveProductOptions.Metadata = prod.Metadata;
        saveProductOptions.Name = prod.Name;
        if (prod.PackageDimensions != null)
        {
            saveProductOptions.PackageDimensions.Height = prod.PackageDimensions.Height;
            saveProductOptions.PackageDimensions.Length = prod.PackageDimensions.Length;
            saveProductOptions.PackageDimensions.Weight = prod.PackageDimensions.Weight;
            saveProductOptions.PackageDimensions.Width = prod.PackageDimensions.Width;
        }

        saveProductOptions.Shippable = prod.Shippable;
        saveProductOptions.UnitLabel = prod.UnitLabel;
        saveProductOptions.Url = prod.Url;
        saveProductOptions.Type = prod.Type;

        return service.Create(saveProductOptions);
    }

    public Product UpdateProduct(Product prod)
    {
        StripeConfiguration.ApiKey = Key;
        var service = new ProductService();
        var updateProductOptions = new ProductUpdateOptions
        {
            Active = prod.Active
        };

        //if (prod.Attributes != null && prod.Attributes.Count > 0)
        //    updateProductOptions.Attributes = prod.Attributes;
        //if (prod.Caption != string.Empty)
        //    updateProductOptions.Caption = prod.Caption;
        //updateProductOptions.DeactivateOn = prod.DeactivateOn;
        if (prod.Description != string.Empty)
            updateProductOptions.Description = prod.Description;
        if (prod.Images != null)
            updateProductOptions.Images = prod.Images;
        updateProductOptions.Metadata = prod.Metadata;
        updateProductOptions.Name = prod.Name;
        if (prod.PackageDimensions != null)
        {
            updateProductOptions.PackageDimensions.Height = prod.PackageDimensions.Height;
            updateProductOptions.PackageDimensions.Length = prod.PackageDimensions.Length;
            updateProductOptions.PackageDimensions.Weight = prod.PackageDimensions.Weight;
            updateProductOptions.PackageDimensions.Width = prod.PackageDimensions.Width;
        }

        if (prod.Shippable != null)
            updateProductOptions.Shippable = prod.Shippable;
        if (prod.UnitLabel != null)
            updateProductOptions.UnitLabel = prod.UnitLabel;
        if (prod.Url != null)
            updateProductOptions.Url = prod.Url;

        return service.Update(prod.Id, updateProductOptions);
    }
}