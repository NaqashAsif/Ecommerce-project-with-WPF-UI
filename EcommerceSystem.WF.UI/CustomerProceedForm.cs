using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
using EcommerceSystem.DAL.Repositories;
using EcommerceSystem.Services;
namespace EcommerceSystem.WF.UI
{
    public partial class CustomerProceedForm : Form
    {
        private IProductService _productService;
        private ICustomerService _customerService;

        public CustomerProceedForm()
        {
            InitializeComponent();
            var customerRepository = new CustomerRepository();
            _customerService = new CustomerService(customerRepository);
            _productService = new ProductService();
            LoadProducts(); 
        }

        private async void LoadProducts()
        {
            try
            {
                List<ProductDto> products = await _productService.ViewProductsAsync(); // Fetch products asynchronously

                if (products == null || products.Count == 0)
                {
                    MessageBox.Show("No products available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridView1.AutoGenerateColumns = true; // Automatically generate columns based on ProductDto properties
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Fill available space
                    dataGridView1.DataSource = products; // Set DataSource to the list of products
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBox1.Text, out int productId) && int.TryParse(textBox2.Text, out int quantity))
                {
                    var customerId = await _customerService.GetCustomerIdAsync();

                    if (customerId.HasValue)
                    {
                        var amount = await _customerService.PlaceOrderAsync(productId, customerId.Value, quantity);
                        MessageBox.Show($"Order placed successfully. Amount: {amount}", "Order Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Customer ID not found. Please ensure you are logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter valid Product ID and Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void CustomerProceedForm_Load(object sender, EventArgs e)
        {
        }
    }
}
