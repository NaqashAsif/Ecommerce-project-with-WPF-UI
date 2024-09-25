using System.Windows;
using EcommerceSystem.Core.Services;
using EcommerceSystem.UI.ViewModels;

namespace EcommerceSystem.UI
{
    public partial class ViewProductsWindow : Window
    {
        public ViewProductsWindow(IProductService productService)
        {
            InitializeComponent();
            DataContext = new ViewProductsViewModel(productService, this);
        }
    }
}
