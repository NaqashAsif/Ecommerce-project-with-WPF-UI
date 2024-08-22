using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.Core.Services;
using EcommerceSystem.DAL.DataBaseContext;
namespace EcommerceSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepostory _customerRepostory;
        public CustomerService(ICustomerRepostory customerRepostory)
        {
            _customerRepostory = customerRepostory;
        }
        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            await _customerRepostory.AddCustomerAsync(customerDto);
        }
        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            
            return await _customerRepostory.GetAllCustomersAsync();
        }

        public async Task<string> PlaceOrderAsync(int productId, int customerId, int quantity) 
        {
            return await _customerRepostory.PlaceOrderAsync(productId, customerId, quantity);
        }
        public async Task<int?> GetCustomerIdAsync()
        {
            return await _customerRepostory.GetCustomerIdAsync();
        }
    }
}
