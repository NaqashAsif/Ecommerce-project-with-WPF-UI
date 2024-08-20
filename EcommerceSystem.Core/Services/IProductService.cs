using EcommerceSystem.Core.DTOS;
namespace EcommerceSystem.Core.Services
{
    public interface IProductService
    {
        public Task RemoveProductAsync(int Id);
        public Task AddProductAsync(ProductDto productDto);
        public Task ViewProductsAsync();
        public Task UpdateProductAsync(int Id, ProductDto productDto);
    }
}
