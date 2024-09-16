using EcommerceSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EcommerceSystem.UI
{
    public partial class DeleteProductWindow : Window
    {
        private readonly IProductService _productService;

        public DeleteProductWindow(IProductService productService)
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
        private async void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(IdTextBox.Text);
                await _productService.RemoveProductAsync(id);
                MessageBox.Show("Product removed successfully!");
                IdTextBox.Clear();
                LoadProducts(); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid product ID.", "Input Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the product: {ex.Message}", "Error");
            }
        }
        private void IdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                IdPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                IdPlaceholder.Visibility = Visibility.Collapsed;
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
