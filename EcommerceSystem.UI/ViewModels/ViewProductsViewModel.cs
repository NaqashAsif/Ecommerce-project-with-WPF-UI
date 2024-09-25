using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
namespace EcommerceSystem.UI.ViewModels
{
    public class ViewProductsViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;
        private readonly Window _window;
        public ObservableCollection<ProductDto> Products { get; set; }
        public ICommand BackToAdminCommand { get; }
        public ViewProductsViewModel(IProductService productService, Window currentWindow)
        {
            _productService = productService;
            _window = currentWindow;
            Products = new ObservableCollection<ProductDto>();
            BackToAdminCommand = new RelayCommand(BackToAdmin);
            Task.Run(LoadProducts);
        }
        private async Task LoadProducts()
        {
            try
            {
                var products = await _productService.ViewProductsAsync();
                if (products != null && products.Count > 0)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        foreach (var product in products)
                        {
                            Products.Add(product);
                        }
                    });
                }
                else
                {
                    MessageBox.Show("No products available.", "Information");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving products: {ex.Message}", "Error");
            }
        }
        private void BackToAdmin()
        {
            var adminWindow = new AdminWindow(_productService);
            adminWindow.Show();
            _window.Close();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}