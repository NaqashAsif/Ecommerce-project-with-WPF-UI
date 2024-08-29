using System.Windows;
using EcommerceSystem.Core.Services;
namespace EcommerceSystem.UI
{
    public partial class ViewProductsWindow : Window
    {
        private readonly IProductService _productService;
        public ViewProductsWindow(IProductService productService)
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
                ProductsListBox.ItemsSource = products;
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
    }
}
