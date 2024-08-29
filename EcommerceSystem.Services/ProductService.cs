using EcommerceSystem.Core.Services;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.Core.DTOS;
using EcommerceSystem.DAL;
namespace EcommerceSystem.Services
{
    public class ProductService: IProductService
    {
        private IProductRepostory productRepostory=new ProductRepostory();
        public ProductService()
        {
            _productRepostory = productRepostory;
        }
        private readonly IProductRepostory _productRepostory;
        public ProductService(IProductRepostory productRepostory)
        {
            _productRepostory = productRepostory;
        }
        public async Task RemoveProductAsync(int Id)
        {
            await _productRepostory.RemoveProductAsync(Id);

        }
        public async Task AddProductAsync(ProductDto productDto)
        {
            await _productRepostory.AddProductAsync(productDto);
        }
        public async Task<List<ProductDto>> ViewProductsAsync()
        {
            return await _productRepostory.ViewProductsAsync();
        }
        public async Task UpdateProductAsync(int Id, ProductDto productDto)
        {
            await _productRepostory.UpdateProductAsync(Id,productDto);
        }
    }
}
