using EcommerceSystem.Core.DTOS;
using EcommerceSystem.DAL.DataBaseContext;
using EcommerceSystem.DAL;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.DAL.Entities;

namespace EcommerceSystem.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private EcommerceSystemdb GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<EcommerceSystemdb>()
                .UseInMemoryDatabase(databaseName: "EcommerceSystemTestDb")
                .Options;

            var dbContext = new EcommerceSystemdb(options);
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        [Test]
        public async Task AddProductAsync_ShouldAddProduct()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new ProductRepostory(context);
            var productDto = new ProductDto { Name = "Test Product", Price = 100m, Stock = 10 };

            // Act
            await repository.AddProductAsync(productDto);

            // Assert
            var product = await context.Products.FirstOrDefaultAsync();
            Assert.IsNotNull(product);
            Assert.AreEqual("Test Product", product.Name);
            Assert.AreEqual(100m, product.Price);
            Assert.AreEqual(10, product.Stock);
        }

        [Test]
        public async Task RemoveProductAsync_ShouldRemoveProduct()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var product = new Product { Name = "Test Product", Price = 100m, Stock = 10 };
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            var repository = new ProductRepostory(context);

            // Act
            await repository.RemoveProductAsync(product.Id);

            // Assert
            var productInDb = await context.Products.FindAsync(product.Id);
            Assert.IsNull(productInDb);
        }

        [Ignore("ADO.NET")]
        public async Task ViewProductsAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            context.Products.AddRange(
                new Product { Name = "Product 1", Price = 50m, Stock = 5 },
                new Product { Name = "Product 2", Price = 150m, Stock = 15 }
            );
            await context.SaveChangesAsync();
            var repository = new ProductRepostory(context);

            // Act
            var productDtos = await repository.ViewProductsAsync();

            // Assert
            Assert.AreEqual(2, productDtos.Count);
            Assert.IsTrue(productDtos.Any(p => p.Name == "Product 1"));
            Assert.IsTrue(productDtos.Any(p => p.Name == "Product 2"));
        }

        [Test]
        public async Task UpdateProductAsync_ShouldUpdateProductDetails()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var product = new Product { Name = "Original Name", Price = 50m, Stock = 5 };
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            var repository = new ProductRepostory(context);
            var updatedProductDto = new ProductDto { Name = "Updated Name", Price = 100m, Stock = 10 };

            // Act
            await repository.UpdateProductAsync(product.Id, updatedProductDto);

            // Assert
            var updatedProduct = await context.Products.FindAsync(product.Id);
            Assert.AreEqual("Updated Name", updatedProduct.Name);
            Assert.AreEqual(100m, updatedProduct.Price);
            Assert.AreEqual(10, updatedProduct.Stock);
        }
    }
}
