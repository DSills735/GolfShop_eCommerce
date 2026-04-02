namespace Sills.GolfShop.eCommerceAPI.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string customerName { get; set; }

        public string shippingAddress { get; set; } = string.Empty;

        // add total price?

        // need m2m rel with product
    }
}
