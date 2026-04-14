namespace Sills.GolfShop.eCommerceAPI.Mapping
{
    public static class ProductMapper
    {
        public static DTO.ProductDTO ToDTO(this Models.Product product)
        {
            if (product == null) return null;
            return new DTO.ProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock
            };
        }
    }
}
