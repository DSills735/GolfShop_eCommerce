namespace Sills.GolfShop.eCommerceAPI.Helpers
{
    public class SortingParameters
    {
        public string name { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }

        public string? sortBy { get; set; } = null;


    }
}
