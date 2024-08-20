using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.DAL.DataBaseContext;
using EcommerceSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace EcommerceSystem.DAL
{
    public class ProductRepostory: IProductRepostory
    {
        public async Task RemoveProductAsync(int Id)
        {
            var context = new EcommerceSystemdb();
            var product = await context.Products.FindAsync(Id);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                Console.WriteLine("Product removed successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            var context = new EcommerceSystemdb();
            

            var product = new Product { Name = productDto.Name, Price = productDto.Price, Stock = productDto.Stock };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            Console.WriteLine("Product added successfully!");
        }

        public async Task ViewProductsAsync()
        {
            var context = new EcommerceSystemdb();
            var products = await context.Products.ToListAsync();
            Console.WriteLine("Product List:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            }
        }
        public async Task UpdateProductAsync(int Id, ProductDto productDto)
        {
            var context = new EcommerceSystemdb();
            var product = await context.Products.FindAsync(Id);
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.Stock = productDto.Stock;
                await context.SaveChangesAsync();
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
    }
}
