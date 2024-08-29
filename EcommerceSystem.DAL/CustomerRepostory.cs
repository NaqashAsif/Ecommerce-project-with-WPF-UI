using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.DAL.DataBaseContext;
using EcommerceSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace EcommerceSystem.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepostory
    {
        private readonly EcommerceSystemdb _context;
        public CustomerRepository()
        {
            _context = new EcommerceSystemdb();
        }
        public CustomerRepository(EcommerceSystemdb context)
        {
            _context=context;
        }
        public async Task<List<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers
                .FromSqlRaw("EXEC GetAllCustomers")
                .ToListAsync();
            var customerDtos = customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                ShippingAddress = c.ShippingAddress
            }).ToList();
            return customerDtos;
        }
        //public async Task<List<CustomerDto>> GetAllCustomersAsync()
        //{
        //    var customers = await _context.Customers
        //        .FromSqlRaw("EXEC GetAllCustomers")
        //        .ToListAsync();
        //    var customerDtos = customers.Select(c => new CustomerDto
        //    {
        //        Id = c.Id,
        //        Name = c.Name,
        //        Email = c.Email,
        //        ShippingAddress = c.ShippingAddress
        //    }).ToList();
        //    return customerDtos;
        //}
        public async Task AddCustomerAsync(CustomerDto customerDto)
        {
            var customer = new Customer { Name = customerDto.Name, Email = customerDto.Email, ShippingAddress = customerDto.ShippingAddress };
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            Console.WriteLine("Customer added successfully!");
        }
        public async Task<int?> GetCustomerIdAsync()
        {
            var customerId = await _context.Customers
                .OrderByDescending(c => c.Id)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();
            return customerId;
        }
        public async Task<string> PlaceOrderAsync(int productId,int customerId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
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
            var customer = await _context.Customers.FindAsync(customerId);
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
            _context.Orders.Add(order);
            _context.OrderDetails.AddRange(order.OrderDetails);
            await _context.SaveChangesAsync();
            return $"Order placed successfully! Total Amount: {order.TotalAmount:C}";
        }
    }
}
