using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D365BCConnectorAPIGear;
using Newtonsoft.Json;

namespace BCStripeSync
{
    public class SalesQuoteHeader : BaseObject
    {
        [JsonProperty("@odata.etag")]
        public string OdataEtag { get; set; }

        [JsonProperty("documentType")]
        public string DocumentType { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("stripeInvoiceId")]
        public string StripeInvoiceId { get; set; }

        [JsonProperty("stripeAutoPay")]
        public bool StripeAutoPay { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("stripeInvoicePdf")]
        public string StripeInvoicePdf { get; set; }

        [JsonProperty("stripePaid")]
        public bool StripePaid { get; set; }

        [JsonProperty("stripePaymentId")]
        public string StripePaymentId { get; set; }

        [JsonProperty("stripeQuoteId")]
        public string StripeQuoteId { get; set; }

        [JsonProperty("sellToAddress")]
        public string SellToAddress { get; set; }

        [JsonProperty("sellToAddress2")]
        public string SellToAddress2 { get; set; }

        [JsonProperty("sellToCity")]
        public string SellToCity { get; set; }

        [JsonProperty("sellToContact")]
        public string SellToContact { get; set; }

        [JsonProperty("sellToContactNo")]
        public string SellToContactNo { get; set; }

        [JsonProperty("sellToCountryRegionCode")]
        public string SellToCountryRegionCode { get; set; }

        [JsonProperty("sellToCounty")]
        public string SellToCounty { get; set; }

        [JsonProperty("sellToCustomerName")]
        public string SellToCustomerName { get; set; }

        [JsonProperty("sellToCustomerName2")]
        public string SellToCustomerName2 { get; set; }

        [JsonProperty("sellToCustomerNo")]
        public string SellToCustomerNo { get; set; }

        [JsonProperty("sellToCustomerTemplCode")]
        public string SellToCustomerTemplCode { get; set; }

        [JsonProperty("sellToEMail")]
        public string SellToEMail { get; set; }

        [JsonProperty("sellToICPartnerCode")]
        public string SellToICPartnerCode { get; set; }

        [JsonProperty("sellToPhoneNo")]
        public string SellToPhoneNo { get; set; }

        [JsonProperty("sellToPostCode")]
        public string SellToPostCode { get; set; }

        [JsonProperty("sendICDocument")]
        public bool SendICDocument { get; set; }

        [JsonProperty("sentAsEmail")]
        public bool SentAsEmail { get; set; }

        [JsonProperty("ship")]
        public bool Ship { get; set; }

        [JsonProperty("shipToAddress")]
        public string ShipToAddress { get; set; }

        [JsonProperty("shipToAddress2")]
        public string ShipToAddress2 { get; set; }

        [JsonProperty("shipToCity")]
        public string ShipToCity { get; set; }

        [JsonProperty("shipToCode")]
        public string ShipToCode { get; set; }

        [JsonProperty("shipToContact")]
        public string ShipToContact { get; set; }

        [JsonProperty("shipToCountryRegionCode")]
        public string ShipToCountryRegionCode { get; set; }

        [JsonProperty("shipToCounty")]
        public string ShipToCounty { get; set; }

        [JsonProperty("shipToName")]
        public string ShipToName { get; set; }

        [JsonProperty("shipToName2")]
        public string ShipToName2 { get; set; }

        [JsonProperty("shipToPostCode")]
        public string ShipToPostCode { get; set; }

        [JsonProperty("shipToUPSZone")]
        public string ShipToUPSZone { get; set; }

        [JsonProperty("balAccountNo")]
        public string BalAccountNo { get; set; }

        [JsonProperty("balAccountType")]
        public string BalAccountType { get; set; }

        [JsonProperty("billToAddress")]
        public string BillToAddress { get; set; }

        [JsonProperty("billToAddress2")]
        public string BillToAddress2 { get; set; }

        [JsonProperty("billToCity")]
        public string BillToCity { get; set; }

        [JsonProperty("billToContact")]
        public string BillToContact { get; set; }

        [JsonProperty("billToContactNo")]
        public string BillToContactNo { get; set; }

        [JsonProperty("billToCountryRegionCode")]
        public string BillToCountryRegionCode { get; set; }

        [JsonProperty("billToCounty")]
        public string BillToCounty { get; set; }

        [JsonProperty("billToCustomerNo")]
        public string BillToCustomerNo { get; set; }

        [JsonProperty("billToCustomerTemplCode")]
        public string BillToCustomerTemplCode { get; set; }

        [JsonProperty("billToICPartnerCode")]
        public string BillToICPartnerCode { get; set; }

        [JsonProperty("billToName")]
        public string BillToName { get; set; }

        [JsonProperty("billToName2")]
        public string BillToName2 { get; set; }

        [JsonProperty("billToPostCode")]
        public string BillToPostCode { get; set; }

        [JsonProperty("systemId")]
        public string SystemId { get; set; }

        [JsonProperty("customerDiscGroup")]
        public string CustomerDiscGroup { get; set; }

        [JsonProperty("customerPostingGroup")]
        public string CustomerPostingGroup { get; set; }

        [JsonProperty("customerPriceGroup")]
        public string CustomerPriceGroup { get; set; }

        [JsonProperty("dimensionSetID")]
        public int DimensionSetID { get; set; }

        [JsonProperty("directDebitMandateID")]
        public string DirectDebitMandateID { get; set; }

        [JsonProperty("docNoOccurrence")]
        public int DocNoOccurrence { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("allowLineDisc")]
        public bool AllowLineDisc { get; set; }

    }
}
