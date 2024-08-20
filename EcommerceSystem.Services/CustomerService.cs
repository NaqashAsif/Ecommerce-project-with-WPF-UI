using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.Core.Services;
using EcommerceSystem.DAL;
using EcommerceSystem.DAL.Repositories;
namespace EcommerceSystem.Services
{
    public class CustomerService : ICustomerService
    {
        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            ICustomerRepostory customerRepostory = new CustomerRepository();
            await customerRepostory.AddCustomerAsync(customerDto);
        }

        public async Task<string> PlaceOrderAsync(int productId, int customerId, int quantity) 
        {
            ICustomerRepostory customerRepostory = new CustomerRepository();
            return await customerRepostory.PlaceOrderAsync(productId, customerId, quantity);
        }
        public async Task<int?> GetCustomerIdAsync()
        {
            ICustomerRepostory customerRepostory = new CustomerRepository();
            return await customerRepostory.GetCustomerIdAsync();
        }
    }
}
