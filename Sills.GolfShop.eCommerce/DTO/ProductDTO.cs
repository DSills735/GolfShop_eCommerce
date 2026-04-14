namespace Sills.GolfShop.eCommerceAPI.DTO
{
    public record ProductUpdateDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int QuantityInStock { get; init; }
    }
}
