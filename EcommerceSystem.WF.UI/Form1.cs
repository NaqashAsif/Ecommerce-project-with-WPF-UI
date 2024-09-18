namespace EcommerceSystem.WF.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewCustomerForm newCustomerForm = new NewCustomerForm();
            newCustomerForm.Show();
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExistingButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
