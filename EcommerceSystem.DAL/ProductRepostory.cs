using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.DAL.DataBaseContext;
using EcommerceSystem.DAL.Entities;
using Microsoft.Data.SqlClient;
using System.Configuration;
namespace EcommerceSystem.DAL
{
    public class ProductRepostory: IProductRepostory
    {
        private readonly string connectionString;

        public ProductRepostory()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
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
            var products = new List<Product>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT Id, Name, Price, Stock FROM Products";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            products.Add(new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Stock = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
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
