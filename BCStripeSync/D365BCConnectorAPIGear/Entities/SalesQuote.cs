using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear
{
    public class SalesQuote : BaseObject
    {
        [JsonProperty("externalDocumentNumber")]
        public string? ExternalDocumentNumber { get; set; }

        [JsonProperty("documentDate")]
        public DateTime DocumentDate { get; set; }

        [JsonProperty("postingDate")]
        public DateTime PostingDate { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("customerId")]
        public Guid CustomerId { get; set; }

        [JsonProperty("customerNumber")]
        public string? CustomerNumber { get; set; }

        [JsonProperty("customerName")]
        public string? CustomerName { get; set; }

        [JsonProperty("billToName")]
        public string? BillToName { get; set; }

        [JsonProperty("billToCustomerId")]
        public Guid BillToCustomerId { get; set; }

        [JsonProperty("billToCustomerNumber")]
        public string? BillToCustomerNumber { get; set; }

        [JsonProperty("shipToName")]
        public string? ShipToName { get; set; }

        [JsonProperty("shipToContact")]
        public string? ShipToContact { get; set; }

        [JsonProperty("sellToAddressLine1")]
        public string? SellToAddressLine1 { get; set; }

        [JsonProperty("sellToAddressLine2")]
        public string? SellToAddressLine2 { get; set; }

        [JsonProperty("sellToCity")]
        public string? SellToCity { get; set; }

        [JsonProperty("sellToCountry")]
        public string? SellToCountry { get; set; }

        [JsonProperty("sellToState")]
        public string? SellToState { get; set; }

        [JsonProperty("sellToPostCode")]
        public string? SellToPostCode { get; set; }

        [JsonProperty("billToAddressLine1")]
        public string? BillToAddressLine1 { get; set; }

        [JsonProperty("billToAddressLine2")]
        public string? BillToAddressLine2 { get; set; }

        [JsonProperty("billToCity")]
        public string? BillToCity { get; set; }

        [JsonProperty("billToCountry")]
        public string? BillToCountry { get; set; }

        [JsonProperty("billToState")]
        public string? BillToState { get; set; }

        [JsonProperty("billToPostCode")]
        public string? BillToPostCode { get; set; }

        [JsonProperty("shipToAddressLine1")]
        public string? ShipToAddressLine1 { get; set; }
            
        [JsonProperty("shipToAddressLine2")]
        public string? ShipToAddressLine2 { get; set; }

        [JsonProperty("shipToCity")]
        public string? ShipToCity { get; set; }

        [JsonProperty("shipToCountry")]
        public string? ShipToCountry { get; set; }

        [JsonProperty("shipToState")]
        public string? ShipToState { get; set; }

        [JsonProperty("shipToPostCode")]
        public string? ShipToPostCode { get; set; }

        [JsonProperty("shortcutDimension1Code")]
        public string? ShortcutDimension1Code { get; set; }

        [JsonProperty("shortcutDimension2Code")]
        public string? ShortcutDimension2Code { get; set; }

        [JsonProperty("currencyId")]
        public Guid CurrencyId { get; set; }

        [JsonProperty("currencyCode")]
        public string? CurrencyCode { get; set; }

        [JsonProperty("paymentTermsId")]
        public Guid PaymentTermsId { get; set; }

        [JsonProperty("shipmentMethodId")]
        public Guid ShipmentMethodId { get; set; }

        [JsonProperty("salesperson")]
        public string? Salesperson { get; set; }

        [JsonProperty("discountAmount")]
        public decimal DiscountAmount { get; set; }

        [JsonProperty("totalAmountExcludingTax")]
        public decimal TotalAmountExcludingTax { get; set; }

        [JsonProperty("totalTaxAmount")]
        public decimal TotalTaxAmount { get; set; }

        [JsonProperty("totalAmountIncludingTax")]
        public decimal TotalAmountIncludingTax { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("sentDate")]
        public DateTime SentDate { get; set; }

        [JsonProperty("validUntilDate")]
        public DateTime ValidUntilDate { get; set; }

        [JsonProperty("acceptedDate")]
        public DateTime AcceptedDate { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }

        [JsonProperty("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

    }
}
