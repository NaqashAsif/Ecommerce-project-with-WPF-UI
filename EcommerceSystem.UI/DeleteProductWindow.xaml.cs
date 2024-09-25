using EcommerceSystem.Core.Services;
using System.Windows;
namespace EcommerceSystem.UI
{
    public partial class DeleteProductWindow : Window
    {
        public DeleteProductWindow(IProductService productService)
        {
            InitializeComponent();
            DataContext = new DeleteProductViewModel(productService, this);
        }
    }
}
