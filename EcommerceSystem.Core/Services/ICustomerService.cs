using EcommerceSystem.Core.DTOS;

namespace EcommerceSystem.Core.Services
{
    public interface ICustomerService
    {
        public Task AddCustomerAsync(CustomerDto customerDto);
        public Task<string> PlaceOrderAsync(int productId, int customerId, int quantity);
        public Task<int?> GetCustomerIdAsync();
        public Task<List<CustomerDto>> GetAllCustomersAsync();

    }
}
