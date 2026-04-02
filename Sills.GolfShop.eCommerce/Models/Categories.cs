namespace Sills.GolfShop.eCommerceAPI.Models
{
    public class Categories
    {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Description { get; set; }
                public DateTime? DeletedAt { get; set; }
                //add a list of products with this category??
    }
}
