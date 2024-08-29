using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EcommerceSystem.UI
{
    /// <summary>
    /// Interaction logic for UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        private readonly IProductService _productService;

        public UpdateProductWindow(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
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
        private void RemovePlaceholderText(object sender, System.Windows.RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && textBox.Text == GetPlaceholderText(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }
        private void AddPlaceholderText(object sender, System.Windows.RoutedEventArgs e)
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
            if (textBox == IdTextBox)
                return "Enter Product ID";
            if (textBox == NameTextBox)
                return "Enter new product name";
            if (textBox == PriceTextBox)
                return "Enter new product price";
            if (textBox == StockTextBox)
                return "Enter new product stock";
            return string.Empty;
        }
    }
}
