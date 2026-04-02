namespace Sills.GolfShop.eCommerceAPI.Models
{
    public class Product
    {
        int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
       // public int sku { get; set; } Not sure if useful or not yet. 

        //need m2m rel with sales 
    }
}
