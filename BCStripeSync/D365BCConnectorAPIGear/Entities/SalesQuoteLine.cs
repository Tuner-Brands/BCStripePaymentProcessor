using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365BCConnectorAPIGear
{
    public class SalesQuoteLine : BaseObject 
    {
        [JsonProperty("documentId")]
        public Guid DocumentId { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("itemId")]
        public Guid ItemId { get; set; }

        [JsonProperty("accountId")]
        public Guid AccountId { get; set; }

        [JsonProperty("lineType")]
        public string? LineType { get; set; } 

        [JsonProperty("lineObjectNumber")]
        public string? LineObjectNumber { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("description2")]
        public string Description2 { get; set; }

        [JsonProperty("unitOfMeasureId")]
        public Guid UnitOfMeasureId { get; set; }

        [JsonProperty("unitOfMeasureCode")]
        public string? UnitOfMeasureCode { get; set; }

        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("discountAmount")]
        public decimal DiscountAmount { get; set; }

        [JsonProperty("discountPercent")]
        public decimal DiscountPercent { get; set; }

        [JsonProperty("discountAppliedBeforeTax")]
        public bool DiscountAppliedBeforeTax { get; set; }

        [JsonProperty("amountExcludingTax")]
        public decimal AmountExcludingTax { get; set; }

        [JsonProperty("taxCode")]
        public string TaxCode { get; set; }

        [JsonProperty("taxPercent")]
        public decimal TaxPercent { get; set; }

        [JsonProperty("totalTaxAmount")]
        public decimal TotalTaxAmount { get; set; }

        [JsonProperty("amountIncludingTax")]
        public decimal AmountIncludingTax { get; set; }

        [JsonProperty("netAmount")]
        public decimal NetAmount { get; set; }

        [JsonProperty("netTaxAmount")]
        public decimal NetTaxAmount { get; set; }

        [JsonProperty("netAmountIncludingTax")]
        public decimal NetAmountIncludingTax { get; set; }

        [JsonProperty("itemVariantId")]
        public Guid ItemVariantId { get; set; }

        [JsonProperty("locationId")]
        public Guid LocationId { get; set; }


    }
}
