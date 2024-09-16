using System.Windows;
using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
namespace EcommerceSystem.UI
{
    public partial class AddProductWindow : Window
    {
        private readonly IProductService _productService;
        public AddProductWindow(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }
        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    !decimal.TryParse(PriceTextBox.Text, out decimal price) ||
                    !int.TryParse(StockTextBox.Text, out int stock))
                {
                    MessageBox.Show("Please enter valid values for all fields.", "Input Error");
                    return;
                }
                var productDto = new ProductDto
                {
                    Name = NameTextBox.Text,
                    Price = price,
                    Stock = stock
                };
                await _productService.AddProductAsync(productDto);
                MessageBox.Show("Product added successfully!");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please enter valid values for product details.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the product: {ex.Message}", "Error");
            }
        }
        private void BackToAdmin_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(_productService);
            adminWindow.Show();
            this.Close();  
        }
    }
}
