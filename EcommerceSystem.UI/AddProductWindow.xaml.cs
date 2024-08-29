using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
using System.Windows;
using System.Windows.Controls;
namespace EcommerceSystem.UI
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private readonly IProductService _productService;

        public AddProductWindow(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
            SetPlaceholderText();
        }
        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductDto productDto = new ProductDto
                {
                    Name = NameTextBox.Text,
                    Price = decimal.Parse(PriceTextBox.Text),
                    Stock = int.Parse(StockTextBox.Text)
                };

                await _productService.AddProductAsync(productDto);

                MessageBox.Show("Product added successfully!");
                ClearInputFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values for price and stock.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void ClearInputFields()
        {
            NameTextBox.Clear();
            PriceTextBox.Clear();
            StockTextBox.Clear();
        }
        private void SetPlaceholderText()
        {
            NameTextBox.Text = "Enter product name";
            PriceTextBox.Text = "Enter price";
            StockTextBox.Text = "Enter stock quantity";
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text == GetPlaceholderText(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = GetPlaceholderText(textBox);
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        private string GetPlaceholderText(TextBox textBox)
        {
            if (textBox == NameTextBox)
                return "Enter product name";
            if (textBox == PriceTextBox)
                return "Enter price";
            if (textBox == StockTextBox)
                return "Enter stock quantity";
            return string.Empty;
        }
    }
}
