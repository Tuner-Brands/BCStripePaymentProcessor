using Newtonsoft.Json;

namespace D365BCConnectorAPIGear;

public class Item : BaseObject
{
    [JsonProperty("displayName")] public string? DisplayName { get; set; }

    [JsonProperty("displayName2")] public string? DisplayName2 { get; set; }

    [JsonProperty("type")] public string? Type { get; set; }

    [JsonProperty("itemCategoryId")] public Guid ItemCategoryId { get; set; }

    [JsonProperty("itemCategoryCode")] public string? ItemCategoryCode { get; set; }

    [JsonProperty("blocked")] public bool Blocked { get; set; }

    [JsonProperty("gtin")] public string? Gtin { get; set; }

    [JsonProperty("inventory")] public decimal Inventory { get; set; }

    [JsonProperty("unitPrice")] public decimal UnitPrice { get; set; }

    [JsonProperty("priceIncludesTax")] public bool PriceIncludesTax { get; set; }

    [JsonProperty("unitCost")] public decimal UnitCost { get; set; }

    [JsonProperty("taxGroupId")] public Guid TaxGroupId { get; set; }

    [JsonProperty("taxGroupCode")] public string? TaxGroupCode { get; set; }

    [JsonProperty("baseUnitOfMeasureId")] public Guid BaseUnitOfMeasureId { get; set; }

    [JsonProperty("baseUnitOfMeasureCode")]
    public string? BaseUnitOfMeasureCode { get; set; }

    [JsonProperty("generalProductPostingGroupId")]
    public Guid GeneralProductPostingGroupId { get; set; }

    [JsonProperty("generalProductPostingGroupCode")]
    public string? GeneralProductPostingGroupCode { get; set; }

    [JsonProperty("inventoryPostingGroupId")]
    public Guid InventoryPostingGroupId { get; set; }

    [JsonProperty("inventoryPostingGroupCode")]
    public string? InventoryPostingGroupCode { get; set; }

    [JsonProperty("lastModifiedDateTime")] public DateTime LastModifiedDateTime { get; set; }
}