namespace ACS_PACLAR
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }
        private void main_load(object sender, EventArgs e)
        {

        }

        private void clientsBtn_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();

            clientsForm.Show();

            this.Hide();
        }

        private void bookingsBtn_Click(object sender, EventArgs e)
        {
            BookingsForm bookingsForm = new BookingsForm();

            bookingsForm.Show();

            this.Hide();

        }
        private void servicesBtn_Click(object sender, EventArgs e)
        {
            ServicesForm servicesForm = new ServicesForm();

            servicesForm.Show();

            this.Hide();

        }
        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm();

            inventoryForm.Show();

            this.Hide();
        }

        private void billingBtn_Click(object sender, EventArgs e)
        {
            BillingForm billingForm = new BillingForm();

            billingForm.Show();

            this.Hide();
        }
    }
}
