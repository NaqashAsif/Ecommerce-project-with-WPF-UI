using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
using EcommerceSystem.UI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
public class DeleteProductViewModel : INotifyPropertyChanged
{
    private readonly IProductService _productService;
    private Window _window;
    private string _productId;
    private ObservableCollection<ProductDto> _products;
    public string ProductId
    {
        get => _productId;
        set { _productId = value; OnPropertyChanged(); }
    }
    public ObservableCollection<ProductDto> Products
    {
        get => _products;
        set { _products = value; OnPropertyChanged(); }
    }
    public ICommand DeleteProductCommand { get; }
    public ICommand BackToAdminCommand { get; }
    public DeleteProductViewModel(IProductService productService, Window currentWindow)
    {
        _productService = productService;
        _window = currentWindow;
        DeleteProductCommand = new RelayCommand(async () => await DeleteProduct());
        BackToAdminCommand = new RelayCommand(BackToAdmin);
        LoadProducts();
    }
    private async Task DeleteProduct()
    {
        try
        {
            if (!int.TryParse(ProductId, out int productId))
            {
                MessageBox.Show("Please enter a valid Product ID.", "Input Error");
                return;
            }
            await _productService.RemoveProductAsync(productId);
            MessageBox.Show("Product deleted successfully!", "Success");
            LoadProducts();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while deleting the product: {ex.Message}", "Error");
        }
    }
    private async void LoadProducts()
    {
        var products = await _productService.ViewProductsAsync();
        Products = new ObservableCollection<ProductDto>(products);
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
