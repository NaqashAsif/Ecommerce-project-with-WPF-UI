using EcommerceSystem.Core.Services;
using EcommerceSystem.DAL;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.Core.DTOS;
using EcommerceSystem.DAL.DataBaseContext;
namespace EcommerceSystem.Services
{
    public class ProductService: IProductService
    {
        public async Task RemoveProductAsync(int Id)
        {
            IProductRepostory productRepostory = new ProductRepostory();
            await productRepostory.RemoveProductAsync(Id);

        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            IProductRepostory productRepostory = new ProductRepostory();
            await productRepostory.AddProductAsync(productDto);
        }

        public async Task ViewProductsAsync()
        {
            IProductRepostory productRepostory = new ProductRepostory();
            await productRepostory.ViewProductsAsync();
        }

        public async Task UpdateProductAsync(int Id, ProductDto productDto)
        {
            IProductRepostory productRepostory = new ProductRepostory();
            await productRepostory.UpdateProductAsync(Id,productDto);
        }
    }
}
