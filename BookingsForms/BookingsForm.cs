using ACS_PACLAR.BookingsForms;
using ACS_PACLAR.ClientForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACS_PACLAR
{
    public partial class BookingsForm : Form
    {

        private SqlConnection connection;

        public BookingsForm()
        {
            InitializeComponent();

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=acsDB;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);
            LoadBookings();
        }

        private void LoadBookings()
        {
            using (SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=acsDB;Trusted_Connection=True;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT ClientName, BookingDate, TotalAmount FROM Bookings";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    bookingsData.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bookings: " + ex.Message);
                }
            }
        }

        private void clientBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void backBtn(object sender, EventArgs e)
        {
            Main MainForm = new Main();

            MainForm.Show();

            this.Hide();

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddBookingForm AddBooking = new AddBookingForm();

            if (AddBooking.ShowDialog() == DialogResult.OK)
            {
                LoadBookings();
            }
        }

    }
}
