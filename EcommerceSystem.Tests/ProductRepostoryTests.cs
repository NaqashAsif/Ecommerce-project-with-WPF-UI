using EcommerceSystem.Core.DTOS;
using EcommerceSystem.DAL.DataBaseContext;
using EcommerceSystem.DAL;
using Microsoft.EntityFrameworkCore;
using EcommerceSystem.DAL.Entities;
namespace EcommerceSystem.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private EcommerceSystemdb _context;
        private ProductRepostory _repoistory;

        [SetUp]
        public void Setup() 
        {
            var options = new DbContextOptionsBuilder<EcommerceSystemdb>()
                .UseInMemoryDatabase(databaseName: "EcommerceSystemTestDb")
                .Options;
            var dbContext = new EcommerceSystemdb(options);
            dbContext.Database.EnsureCreated();
            _context = dbContext;
            _repoistory = new ProductRepostory(_context);
        }

        [Test]
        public async Task AddProductAsync_ShouldAddProduct()
        {
            // Arrange
            var productDto = new ProductDto { Name = "Test Product", Price = 100m, Stock = 10 };
            // Act
            await _repoistory.AddProductAsync(productDto);
            // Assert
            var product = await _context.Products.FirstOrDefaultAsync();
            Assert.IsNotNull(product);
            Assert.AreEqual("Test Product", product.Name);
            Assert.AreEqual(100m, product.Price);
            Assert.AreEqual(10, product.Stock);
        }

        [Test]
        public async Task RemoveProductAsync_ShouldRemoveProduct()
        {
            // Arrange
            var product = new Product { Name = "Test Product", Price = 100m, Stock = 10 };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            // Act
            await _repoistory.RemoveProductAsync(product.Id);
            // Assert
            var productInDb = await _context.Products.FindAsync(product.Id);
            Assert.IsNull(productInDb);
        }

        [Ignore("ADO.NET")]
        public async Task ViewProductsAsync_ShouldReturnAllProducts()
        {
            // Arrange
            _context.Products.AddRange(
                new Product { Name = "Product 1", Price = 50m, Stock = 5 },
                new Product { Name = "Product 2", Price = 150m, Stock = 15 }
            );
            await _context.SaveChangesAsync();
            // Act
            var productDtos = await _repoistory.ViewProductsAsync();
            // Assert
            Assert.AreEqual(2, productDtos.Count);
            Assert.IsTrue(productDtos.Any(p => p.Name == "Product 1"));
            Assert.IsTrue(productDtos.Any(p => p.Name == "Product 2"));
        }

        [Test]
        public async Task UpdateProductAsync_ShouldUpdateProductDetails()
        {
            // Arrange
            var product = new Product { Name = "Original Name", Price = 50m, Stock = 5 };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            var updatedProductDto = new ProductDto { Name = "Updated Name", Price = 100m, Stock = 10 };
            // Act
            await _repoistory.UpdateProductAsync(product.Id, updatedProductDto);
            // Assert
            var updatedProduct = await _context.Products.FindAsync(product.Id);
            Assert.AreEqual("Updated Name", updatedProduct.Name);
            Assert.AreEqual(100m, updatedProduct.Price);
            Assert.AreEqual(10, updatedProduct.Stock);
        }
    }
}
