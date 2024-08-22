using EcommerceSystem.Core.DTOS;
namespace EcommerceSystem.Core.Repostories
{
    public interface IProductRepostory
    {
        public Task RemoveProductAsync(int Id);
        public Task AddProductAsync(ProductDto productDto);
        public Task<List<ProductDto>> ViewProductsAsync();
        public Task UpdateProductAsync(int Id, ProductDto productDto);
    }
}
