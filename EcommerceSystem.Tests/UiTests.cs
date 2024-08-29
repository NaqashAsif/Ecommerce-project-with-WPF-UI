using Moq;
using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
namespace EcommerceSystem.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private Mock<IProductService> _mockProductService;
        private Mock<ICustomerService> _mockCustomerService;
        [SetUp]
        public void Setup()
        {
            _mockProductService = new Mock<IProductService>();
            _mockCustomerService = new Mock<ICustomerService>();
        }

        [Test]
        public async Task AddProduct_ShouldCallAddProductAsync_WithCorrectProductDto()
        {
            // Arrange
            var productDto = new ProductDto
            {
                Name = "Test Product",
                Price = 100m,
                Stock = 50
            };
            _mockProductService.Setup(s => s.AddProductAsync(It.IsAny<ProductDto>())).Returns(Task.CompletedTask);
            // Act
            await _mockProductService.Object.AddProductAsync(productDto);
            // Assert
            _mockProductService.Verify(s => s.AddProductAsync(It.Is<ProductDto>(p => p.Name == "Test Product" && p.Price == 100m && p.Stock == 50)), Times.Once);
        }

        [Test]
        public async Task RemoveProduct_ShouldCallRemoveProductAsync_WithCorrectId()
        {
            // Arrange
            int productId = 1;
            _mockProductService.Setup(s => s.RemoveProductAsync(productId)).Returns(Task.CompletedTask);
            // Act
            await _mockProductService.Object.RemoveProductAsync(productId);
            // Assert
            _mockProductService.Verify(s => s.RemoveProductAsync(It.Is<int>(id => id == productId)), Times.Once);
        }

        [Test]
        public async Task UpdateProduct_ShouldCallUpdateProductAsync_WithCorrectIdAndProductDto()
        {
            // Arrange
            var productDto = new ProductDto
            {
                Name = "Updated Product",
                Price = 150m,
                Stock = 30
            };
            int productId = 1;
            _mockProductService.Setup(s => s.UpdateProductAsync(productId, productDto)).Returns(Task.CompletedTask);
            // Act
            await _mockProductService.Object.UpdateProductAsync(productId, productDto);
            // Assert
            _mockProductService.Verify(s => s.UpdateProductAsync(It.Is<int>(id => id == productId), It.Is<ProductDto>(p => p.Name == "Updated Product" && p.Price == 150m && p.Stock == 30)), Times.Once);
        }

        [Test]
        public async Task ViewProducts_ShouldReturnCorrectProductsList()
        {
            // Arrange
            var expectedProducts = new List<ProductDto>
            {
                new ProductDto { Id = 1, Name = "Product 1", Price = 100m, Stock = 50 },
                new ProductDto { Id = 2, Name = "Product 2", Price = 200m, Stock = 30 }
            };

            _mockProductService.Setup(s => s.ViewProductsAsync()).ReturnsAsync(expectedProducts);
            // Act
            var result = await _mockProductService.Object.ViewProductsAsync();
            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Product 1", result.First().Name);
        }

        [Test]
        public async Task GetAllCustomers_ShouldReturnCorrectCustomersList()
        {
            // Arrange
            var expectedCustomers = new List<CustomerDto>
            {
                new CustomerDto { Id = 1, Name = "John Doe", Email = "john@example.com", ShippingAddress = "123 Main St" },
                new CustomerDto { Id = 2, Name = "Jane Doe", Email = "jane@example.com", ShippingAddress = "456 Elm St" }
            };
            _mockCustomerService.Setup(s => s.GetAllCustomersAsync()).ReturnsAsync(expectedCustomers);
            // Act
            var result = await _mockCustomerService.Object.GetAllCustomersAsync();
            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("John Doe", result.First().Name);
        }

        [Test]
        public async Task AddCustomer_ShouldCallAddCustomerAsync_WithCorrectCustomerDto()
        {
            // Arrange
            var customerDto = new CustomerDto
            {
                Name = "John Doe",
                Email = "john@example.com",
                ShippingAddress = "123 Main St"
            };
            _mockCustomerService.Setup(s => s.AddCustomerAsync(It.IsAny<CustomerDto>())).Returns(Task.CompletedTask);
            // Act
            await _mockCustomerService.Object.AddCustomerAsync(customerDto);
            // Assert
            _mockCustomerService.Verify(s => s.AddCustomerAsync(It.Is<CustomerDto>(c => c.Name == "John Doe" && c.Email == "john@example.com" && c.ShippingAddress == "123 Main St")), Times.Once);
        }

        [Test]
        public async Task GetCustomerId_ShouldReturnCorrectCustomerId()
        {
            // Arrange
            int expectedCustomerId = 1;
            _mockCustomerService.Setup(s => s.GetCustomerIdAsync()).ReturnsAsync(expectedCustomerId);
            // Act
            var result = await _mockCustomerService.Object.GetCustomerIdAsync();
            // Assert
            Assert.AreEqual(expectedCustomerId, result);
        }

        [Test]
        public async Task PlaceOrder_ShouldCallPlaceOrderAsync_WithCorrectDetails()
        {
            // Arrange
            int productId = 1;
            int customerId = 1;
            int quantity = 2;
            string expectedAmount = "20.00";
            _mockCustomerService.Setup(s => s.PlaceOrderAsync(productId, customerId, quantity)).ReturnsAsync(expectedAmount);
            // Act
            var result = await _mockCustomerService.Object.PlaceOrderAsync(productId, customerId, quantity);
            // Assert
            Assert.AreEqual(expectedAmount, result);
            _mockCustomerService.Verify(s => s.PlaceOrderAsync(productId, customerId, quantity), Times.Once);
        }
    }
}
