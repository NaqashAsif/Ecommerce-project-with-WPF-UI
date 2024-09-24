using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
using EcommerceSystem.UI;
public class AddProductViewModel : INotifyPropertyChanged
{
    private readonly IProductService _productService;
    private Window _window;
    private string _name;
    private string _price;
    private string _stock;
    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(); }
    }

    public string Price
    {
        get => _price;
        set { _price = value; OnPropertyChanged(); }
    }

    public string Stock
    {
        get => _stock;
        set { _stock = value; OnPropertyChanged(); }
    }
    public ICommand AddProductCommand { get; }
    public ICommand BackToAdminCommand { get; }
    public AddProductViewModel(IProductService productService, Window currentWindow)
    {
        _productService = productService;
        _window = currentWindow;

        AddProductCommand = new RelayCommand(async () => await AddProduct());
        BackToAdminCommand = new RelayCommand(BackToAdmin); // Make sure this is correctly initialized
    }
    private async Task AddProduct()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                !decimal.TryParse(Price, out decimal price) ||
                !int.TryParse(Stock, out int stock))
            {
                MessageBox.Show("Please enter valid values for all fields.", "Input Error");
                return;
            }
            var productDto = new ProductDto
            {
                Name = Name,
                Price = price,
                Stock = stock
            };

            await _productService.AddProductAsync(productDto);

            // Notify user about success
            MessageBox.Show("Product added successfully!", "Success");
        }
        catch (FormatException)
        {
            MessageBox.Show("Please enter valid values for product details.", "Input Error");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while adding the product: {ex.Message}", "Error");
        }
    }
    private void BackToAdmin()
    {
        MessageBox.Show("Back button clicked!");
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
