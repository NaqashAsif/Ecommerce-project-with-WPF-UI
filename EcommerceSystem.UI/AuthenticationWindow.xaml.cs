using EcommerceSystem.Core.Services;
using System.Windows;

namespace EcommerceSystem.UI
{
    public partial class AuthenticationWindow : Window
    {
        private readonly IProductService _productService;
        private const string CorrectUsername = "naqash";
        private const string CorrectPassword = "9870648";
        public AuthenticationWindow(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == CorrectUsername && PasswordBox.Password == CorrectPassword)
            {
                var adminWindow = new AdminWindow(_productService);
                adminWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Authentication Error");
            }
        }
        private void BackToMain_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
