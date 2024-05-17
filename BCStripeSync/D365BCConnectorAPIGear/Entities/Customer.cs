using Newtonsoft.Json;

namespace D365BCConnectorAPIGear
{
    public class Customer : BaseObject
    {

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("salespersonCode")]
        public string SalespersonCode { get; set; }

        [JsonProperty("balanceDue")]
        public decimal BalanceDue { get; set; }

        [JsonProperty("creditLimit")]
        public decimal CreditLimit { get; set; }

        [JsonProperty("taxLiable")]
        public bool TaxLiable { get; set; }

        [JsonProperty("taxAreaId")]
        public Guid TaxAreaId { get; set; }

        [JsonProperty("taxAreaDisplayName")]
        public string TaxAreaDisplayName { get; set; }

        [JsonProperty("taxRegistrationNumber")]
        public string TaxRegistrationNumber { get; set; }

        [JsonProperty("currencyId")]
        public Guid CurrencyId { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("paymentTermsId")]
        public Guid PaymentTermsId { get; set; }

        [JsonProperty("shipmentMethodId")]
        public Guid ShipmentMethodId { get; set; }

        [JsonProperty("paymentMethodId")]
        public Guid PaymentMethodId { get; set; }

        [JsonProperty("blocked")]
        public string Blocked { get; set; }

        [JsonProperty("lastModifiedDateTime")]
        public DateTime LastModifiedDateTime { get; set; }

    }
}
