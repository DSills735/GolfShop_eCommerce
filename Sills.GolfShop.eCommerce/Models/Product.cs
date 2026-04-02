namespace Sills.GolfShop.eCommerceAPI.Models
{
    public class Product
    {
        int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        public List<ProductSales> ProductSales { get; } = [];
    }
}
