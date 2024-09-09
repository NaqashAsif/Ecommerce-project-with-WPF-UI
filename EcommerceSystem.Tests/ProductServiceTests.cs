﻿using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.Services;
using Moq;
namespace EcommerceSystem.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Mock<IProductRepostory> _productRepostoryMock;
        private ProductService _productService;

        [SetUp]
        public void Setup()
        {
            _productRepostoryMock=new Mock<IProductRepostory>();
            _productService= new ProductService(_productRepostoryMock.Object);
        }

        [Test]
        public async Task AddProductAsync_ShouldCallAddProductAsyncOnRepository()
        {
            // Arrange
            var productDto = new ProductDto { Name = "Test Product", Price = 100m, Stock = 50 };
            // Act
            await _productService.AddProductAsync(productDto);
            // Assert
            _productRepostoryMock.Verify(r => r.AddProductAsync(It.Is<ProductDto>(p => p.Name == "Test Product" && p.Price == 100m && p.Stock == 50)), Times.Once);
        }
        [Test]
        public async Task ViewProductsAsync_ShouldReturnListOfProducts()
        {
            // Arrange
            var expectedProducts = new List<ProductDto>
            {
                new ProductDto { Id = 1, Name = "Product 1", Price = 100m, Stock = 50 },
                new ProductDto { Id = 2, Name = "Product 2", Price = 200m, Stock = 30 }
            };
            _productRepostoryMock.Setup(r => r.ViewProductsAsync()).ReturnsAsync(expectedProducts);
            // Act
            var result = await _productService.ViewProductsAsync();
            // Assert
            Assert.AreEqual(expectedProducts.Count, result.Count);
            Assert.AreEqual(expectedProducts[0].Name, result[0].Name);
            Assert.AreEqual(expectedProducts[1].Price, result[1].Price);
        }
        [Test]
        public async Task RemoveProductAsync_ShouldCallRemoveProductAsyncOnRepository()
        {
            // Arrange
            int productId = 1;
            // Act
            await _productService.RemoveProductAsync(productId);
            // Assert
            _productRepostoryMock.Verify(r => r.RemoveProductAsync(It.Is<int>(id => id == productId)), Times.Once);
        }
        [Test]
        public async Task UpdateProductAsync_ShouldCallUpdateProductAsyncOnRepository()
        {
            // Arrange
            int productId = 1;
            var productDto = new ProductDto { Name = "Updated Product", Price = 150m, Stock = 30 };
            // Act
            await _productService.UpdateProductAsync(productId, productDto);
            // Assert
            _productRepostoryMock.Verify(r => r.UpdateProductAsync(It.Is<int>(id => id == productId), It.Is<ProductDto>(p => p.Name == "Updated Product" && p.Price == 150m && p.Stock == 30)), Times.Once);
        }
    }
}
