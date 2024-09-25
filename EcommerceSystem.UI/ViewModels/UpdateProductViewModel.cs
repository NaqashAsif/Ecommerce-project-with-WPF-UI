using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;

namespace EcommerceSystem.UI.ViewModels
{
    public class UpdateProductViewModel : INotifyPropertyChanged
    {
        private readonly IProductService _productService;
        private readonly Window _window;
        private ProductDto _selectedProduct;

        public ObservableCollection<ProductDto> Products { get; set; }

        public ProductDto SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged();
                    ((RelayCommand)UpdateProductCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand UpdateProductCommand { get; }
        public ICommand BackToAdminCommand { get; }

        public UpdateProductViewModel(IProductService productService, Window currentWindow)
        {
            _productService = productService;
            _window = currentWindow;
            Products = new ObservableCollection<ProductDto>();
            LoadProducts();

            UpdateProductCommand = new RelayCommand(async () => await UpdateProduct(), CanUpdateProduct);
            BackToAdminCommand = new RelayCommand(BackToAdmin);
        }

        private bool CanUpdateProduct() => SelectedProduct != null;

        private async void LoadProducts()
        {
            try
            {
                var products = await _productService.ViewProductsAsync();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading products: {ex.Message}", "Error");
            }
        }

        private async Task UpdateProduct()
        {
            try
            {
                if (SelectedProduct == null)
                {
                    MessageBox.Show("Please select a product to update.", "Input Error");
                    return;
                }

                await _productService.UpdateProductAsync(SelectedProduct.Id, SelectedProduct);

                // Update the product in the collection
                var index = Products.IndexOf(SelectedProduct);
                if (index >= 0)
                {
                    Products[index] = SelectedProduct; // Update the product in the collection
                }

                MessageBox.Show("Product updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the product: {ex.Message}", "Error");
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
