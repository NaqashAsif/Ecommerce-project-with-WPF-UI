using EcommerceSystem.Core.Services;
using EcommerceSystem.UI.ViewModels;
using System.Windows;

namespace EcommerceSystem.UI
{
    public partial class AddProductWindow : Window
    {
        public AddProductWindow(IProductService productService)
        {
            InitializeComponent();
            DataContext = new AddProductViewModel(productService, this);
        }
    }
}
