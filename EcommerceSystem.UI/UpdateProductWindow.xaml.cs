using EcommerceSystem.Core.Services;
using EcommerceSystem.UI.ViewModels;
using System.Windows;

namespace EcommerceSystem.UI
{
    public partial class UpdateProductWindow : Window
    {
        public UpdateProductWindow(IProductService productService)
        {
            InitializeComponent();
            DataContext = new UpdateProductViewModel(productService, this);
        }
    }
}
