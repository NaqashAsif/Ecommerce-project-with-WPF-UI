using EcommerceSystem.Core.Services;
using EcommerceSystem.Services;
using System.Windows;
namespace EcommerceSystem.UI
{
    public partial class MainWindow : Window
    {
        private readonly IProductService _productService;

        public MainWindow()
        {
            InitializeComponent();
            _productService=new ProductService();
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow(_productService);
            adminWindow.Show();
            this.Close(); 
        }
        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Customer functionality coming soon...");
        }
    }
}
