namespace Sills.GolfShop.eCommerceAPI.DTO
{
    public record ProductDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int QuantityInStock { get; init; }
    }
}
