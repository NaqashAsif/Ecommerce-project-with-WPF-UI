using EcommerceSystem.Core.DTOS;

namespace EcommerceSystem.Core.Repostories
{
    public interface ICustomerRepostory
    {
        public Task AddCustomerAsync(CustomerDto customerDto);
        public Task<string> PlaceOrderAsync(int productId, int customerId, int quantity);
        public Task<int?> GetCustomerIdAsync();

    }
}
