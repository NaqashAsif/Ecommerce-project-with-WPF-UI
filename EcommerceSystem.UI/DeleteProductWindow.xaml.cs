using EcommerceSystem.Core.Services;
using System.Windows;

namespace EcommerceSystem.UI
{
    /// <summary>
    /// Interaction logic for DeleteProductWindow.xaml
    /// </summary>
    public partial class DeleteProductWindow : Window
    {
        private readonly IProductService _productService;

        public DeleteProductWindow(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private async void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(IdTextBox.Text);
                await _productService.RemoveProductAsync(id);
                MessageBox.Show("Product removed successfully!");
                IdTextBox.Clear();
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

        private void IdTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
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
    }
}
