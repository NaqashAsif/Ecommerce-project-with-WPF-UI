using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.DAL.DataBaseContext;
using EcommerceSystem.DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace EcommerceSystem.DAL
{
    public class ProductRepostory : IProductRepostory
    {
        private readonly EcommerceSystemdb _context;
        public ProductRepostory(EcommerceSystemdb context)
        {
            _context = context;
        }
       // private readonly string connectionString;
        public ProductRepostory()
        {
            _context = new EcommerceSystemdb();
           // connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public async Task RemoveProductAsync(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                Console.WriteLine("Product removed successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = new Product { Name = productDto.Name, Price = productDto.Price, Stock = productDto.Stock };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            Console.WriteLine("Product added successfully!");
        }
        public async Task<List<ProductDto>> ViewProductsAsync()
        {
            var products = await _context.Products
        .Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock
        })
        .ToListAsync();

            return products;
            /*var products = new list<product>();

            using (var connection = new sqlconnection(connectionstring))
            {
                await connection.openasync();

                var query = "select id, name, price, stock from products";

                using (var command = new sqlcommand(query, connection))
                {
                    using (var reader = await command.executereaderasync())
                    {
                        while (await reader.readasync())
                        {
                            products.add(new product
                            {
                                id = reader.getint32(0),
                                name = reader.getstring(1),
                                price = reader.getdecimal(2),
                                stock = reader.getint32(3)
                            });
                        }
                    }
                }
            }
            var productdtos = products.select(c => new productdto
            {
                id = c.id,
                name = c.name,
                price = c.price,
                stock = c.stock
            }).tolist();
            return productdtos;*/
        }
        public async Task UpdateProductAsync(int Id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(Id);
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Price = productDto.Price;
                product.Stock = productDto.Stock;
                await _context.SaveChangesAsync();
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
    }
}


