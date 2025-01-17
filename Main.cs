namespace ACS_PACLAR
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


        }
        private void Dashboard_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
