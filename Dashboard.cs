namespace ACS_PACLAR
{
    public partial class Dashboard : Form
    {
        public Dashboard()
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


    }
}
