using EcommerceSystem.Core.DTOS;
using EcommerceSystem.Core.Services;
using EcommerceSystem.DAL.Repositories;
using EcommerceSystem.Services;
namespace EcommerceSystem.WF.UI
{
    public partial class NewCustomerForm : Form
    {
        private readonly ICustomerService _customerService;
        public NewCustomerForm()
        {
            InitializeComponent();
            var customerRepository = new CustomerRepository(); 
            _customerService = new CustomerService(customerRepository);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void NewCustomerForm_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            CustomerDto customerDto = new CustomerDto
            {
                Name = textBox1.Text,
                Email = textBox2.Text,
                ShippingAddress = textBox3.Text
            };

            await _customerService.AddCustomerAsync(customerDto);
            CustomerProceedForm newCustomerForm = new CustomerProceedForm();
            newCustomerForm.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
