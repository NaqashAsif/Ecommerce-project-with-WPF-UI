using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.DAL.DataBaseContext;
using EcommerceSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace EcommerceSystem.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepostory
    {
        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            var context = new EcommerceSystemdb();
            var customer = new Customer { Name = customerDto.Name, Email = customerDto.Email, ShippingAddress = customerDto.ShippingAddress };
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            Console.WriteLine("Customer added successfully!");
        }
        public async Task<int?> GetCustomerIdAsync()
        {
            using var context = new EcommerceSystemdb();
            var customerId = await context.Customers
                .OrderByDescending(c => c.Id)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();
            return customerId;
        }
        public async Task<string> PlaceOrderAsync(int productId,int customerId, int quantity)
        {
            var context = new EcommerceSystemdb();
            var product = await context.Products.FindAsync(productId);
            if (product == null)
            {
                return "Product not found.";
            }
            if (quantity <= 0)
            {
                return "Quantity must be greater than zero.";
            }
            if (quantity > product.Stock)
            {
                return "Quantity exceeds available stock.";
            }
            var customer = await context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return "Customer not found.";
            }
            var order = new Order
            {
                CustomerId = customer.Id,
                TotalAmount = product.Price * quantity,
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail
                    {
                        ProductId = product.Id,
                        Quantity = quantity,
                        Price = product.Price
                    }
                }
            };
            product.Stock -= quantity;
            context.Orders.Add(order);
            context.OrderDetails.AddRange(order.OrderDetails);
            await context.SaveChangesAsync();
            return $"Order placed successfully! Total Amount: {order.TotalAmount:C}";
        }
    }
}
