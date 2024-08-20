using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Repostories;
using EcommerceSystem.Core.Services;
using EcommerceSystem.DAL;
using EcommerceSystem.DAL.Repositories;
using EcommerceSystem.Services;
using System.Text;
StringBuilder headerdesign = new StringBuilder();
headerdesign
            .Append('-', 120)
            .AppendLine()
            .Append(' ', 45)
            .Append("WELCOME TO E-COMMERCE SYSTEM SOFTWARE")
            .Append(' ', 45)
            .AppendLine()
            .Append('-', 120);
Console.WriteLine(headerdesign);
Console.Write("\t\tMAIN MENU\n" +
              "SELECT OPTION FROM GIVEN BELOW:\n" +
              "1:ADMIN\n" +
              "2:CUSTOMER\n" +
              "ENTER OPTION: ");
if (int.Parse(Console.ReadLine()) == 1)
{
    while (true)
    {
        IProductService productService = new ProductService();
        Console.Write("\t\tADMIN MENU\n" +
                       "1:ADD PRODUCTS\n" +
                       "2:REMOVE PRODUCT\n" +
                       "3:UPDATE PRODUCT\n" +
                       "4:VIEW PRODUCT\n" +
                       "5:QUIT\n" +
                       "ENTER OPTION:");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                {
                    ProductDto productDto = new ProductDto();
                    Console.Write("Enter product name:");
                    productDto.Name = Console.ReadLine();

                    Console.Write("Enter product price:");
                    productDto.Price = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter product stock:");
                    productDto.Stock = int.Parse(Console.ReadLine());
                    await productService.AddProductAsync(productDto);
                    break;
                }
            case 2:
                {
                    Console.Write("Enter Id To Remove:");
                    int id = int.Parse(Console.ReadLine());
                    await productService.RemoveProductAsync(id);
                    break;
                }
            case 3:
                {
                    ProductDto productDto = new ProductDto();
                    Console.Write("Enter Id To Update:");
                    int Id = int.Parse(Console.ReadLine());
                    Console.Write("Enter new product name:");
                    productDto.Name = Console.ReadLine();

                    Console.Write("Enter new product price:");
                    productDto.Price = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter new product stock:");
                    productDto.Stock = int.Parse(Console.ReadLine());
                    await productService.UpdateProductAsync(Id, productDto);
                }
                break;
            case 4:
                {
                    await productService.ViewProductsAsync();
                    break;
                }
            case 5:
                return;
        }
        if (choice == 5)
            break;
    }
}
else
{
    Console.Write("1:NEW CUSTOMER\n" +
                      "2:EXISTING CUSTOMER\n" +
                      "ENTER OPTION: ");
    if (int.Parse(Console.ReadLine()) == 1)
    {
        CustomerDto customerDto = new CustomerDto();
        Console.Write("Enter Customer Name");
        customerDto.Name=Console.ReadLine();
        Console.Write("Enter Customer Email");
        customerDto.Email=Console.ReadLine();
        Console.Write("Enter Customer Shipping Address");
        customerDto.ShippingAddress=Console.ReadLine();
        ICustomerRepostory customerRepostory =new CustomerRepository();
        await customerRepostory.AddCustomerAsync(customerDto);
        ProductRepostory productRepostory = new ProductRepostory();
        await productRepostory.ViewProductsAsync();
        Console.Write("Enter Product ID To Order: ");
        int productId=int.Parse(Console.ReadLine());
        Console.Write("Enter Product Quantity To Order: ");
        int quantity= int.Parse(Console.ReadLine());
        var customerId = await customerRepostory.GetCustomerIdAsync();
        if (customerId.HasValue)
        {
            var amount=await customerRepostory.PlaceOrderAsync(productId, customerId.Value, quantity);
            Console.WriteLine(amount);

        }
        else
        {
            Console.WriteLine("Customer is not added in system!");
        }
    }
    else
    {
        Console.WriteLine("Enter Customer ID: ");
        int customerId=int.Parse(Console.ReadLine());
        ICustomerRepostory customerRepostory = new CustomerRepository();
        ProductRepostory productRepostory = new ProductRepostory();
        await productRepostory.ViewProductsAsync();
        Console.Write("Enter Product ID To Order: ");
        int productId = int.Parse(Console.ReadLine());
        Console.Write("Enter Product Quantity To Order: ");
        int quantity = int.Parse(Console.ReadLine());
        string amount=await customerRepostory.PlaceOrderAsync(productId, customerId, quantity);
        Console.WriteLine(amount);
    }
}