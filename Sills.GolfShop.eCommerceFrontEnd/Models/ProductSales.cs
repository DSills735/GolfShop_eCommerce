using Newtonsoft.Json;

namespace Sills.GolfShop.eCommerceFrontEnd.Models;

internal class ProductSales
{
    [JsonProperty("ProductSales")]
    public required List<ProductSale> ProductSalesList { get; set; }
}

internal class ProductSale
{
    [JsonProperty("Id")]
    public int Id { get; set; }
    [JsonProperty("ProductId")]
    public int ProductId { get; set; }
    [JsonProperty("SaleId")]
    public int SaleId { get; set; }
}
