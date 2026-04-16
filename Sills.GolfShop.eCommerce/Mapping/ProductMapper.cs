namespace Sills.GolfShop.eCommerceAPI.Mapping
{
    public static class ProductMapper
    {
        public static DTO.ProductDto ToDTO(this Models.Product product)
        public static DTO.ProductUpdateDto ToDTO(this Models.Product product)
        {
            if (product == null) return null;
            return new DTO.ProductUpdateDTO
            {
                Name = product.Name,
                Description = product.Description,
                QuantityInStock = product.QuantityInStock
            };
        }
    }
}
