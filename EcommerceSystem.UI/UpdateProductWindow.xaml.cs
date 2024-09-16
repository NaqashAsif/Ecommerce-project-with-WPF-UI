using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
using System.Windows;
using System.Windows.Controls;
namespace EcommerceSystem.UI
{
    public partial class UpdateProductWindow : Window
    {
        private readonly IProductService _productService;

        public UpdateProductWindow(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            LoadProducts();
        }
        private async void LoadProducts()
        {
            try
            {
                var products = await _productService.ViewProductsAsync();
                ProductsDataGrid.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading products: {ex.Message}", "Error");
            }
        }
        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as ProductDto;
            if (selectedProduct != null)
            {
                IdTextBox.Text = selectedProduct.Id.ToString();
                NameTextBox.Text = selectedProduct.Name;
                PriceTextBox.Text = selectedProduct.Price.ToString("F2");
                StockTextBox.Text = selectedProduct.Stock.ToString();
            }
        }
        private async void UpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text) ||
                    string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                    string.IsNullOrWhiteSpace(StockTextBox.Text))
                {
                    MessageBox.Show("All fields must be filled out.", "Input Error");
                    return;
                }

                int id = int.Parse(IdTextBox.Text);
                var productDto = new ProductDto
                {
                    Name = NameTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    Stock = int.Parse(StockTextBox.Text)
                };

                await _productService.UpdateProductAsync(id, productDto);
                MessageBox.Show("Product updated successfully!");
                LoadProducts(); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values for product details.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the product: {ex.Message}", "Error");
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
