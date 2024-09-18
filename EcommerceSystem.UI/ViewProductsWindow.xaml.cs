using System.Windows;
using EcommerceSystem.Core.Services;
using EcommerceSystem.Services;
namespace EcommerceSystem.UI
{
    public partial class ViewProductsWindow : Window
    {
        private  IProductService _productService;

        public ViewProductsWindow()
        {
            InitializeComponent();
            _productService = new ProductService();
            LoadProducts();
        }
        private async void LoadProducts()
        {
            try
            {
                var products = await _productService.ViewProductsAsync();
                ProductsDataGrid.ItemsSource = products;

                if (products == null || products.Count == 0)
                {
                    MessageBox.Show("No products available.", "Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving products: {ex.Message}", "Error");
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
