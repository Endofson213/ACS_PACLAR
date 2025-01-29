using ACS_PACLAR.StringMessages;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;

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
            LoadWeeklySchedule();
            FormatDataGridView();
        }
        private void LoadWeeklySchedule()
        {
            using (SqlConnection conn = new SqlConnection(ACSMessages.DBConnectionString))
            {
                string query = @"
SELECT 
    b.BookingId, 
    b.ClientName, 
    cp.Address,  -- Fetch Address from ClientsProfile
    b.BookingDate, 
    b.TotalAmount, 
    bill.PaymentStatus
FROM dbo.Bookings b
LEFT JOIN dbo.Billing bill 
    ON CAST(b.BookingId AS NVARCHAR) = bill.BillingReference
LEFT JOIN dbo.ClientsProfile cp 
    ON b.ClientName = cp.ClientName
ORDER BY b.BookingDate;";


                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                mainData.DataSource = dataTable;
            }
        }
        private void FormatDataGridView()
        {
            mainData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            mainData.Columns["BookingId"].Visible = false;

            mainData.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
            mainData.Columns["PaymentStatus"].HeaderText = "Payment Status";

            if (mainData.Columns.Contains("Address"))
            {
                mainData.Columns["Address"].HeaderText = "Client Address";
            }
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
