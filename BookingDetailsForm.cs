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
    public partial class BookingDetailsForm : Form
    {

        private SqlConnection connection;
        private int clientID;
        private string clientName;
        private int? selectedBookingID;

        // get data from BookingsForm
        public BookingDetailsForm(int clientID, string clientName, int? selectedBookingID = null)
        {
            InitializeComponent();
            this.clientID = clientID;
            this.clientName = clientName;
            this.selectedBookingID = selectedBookingID;

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=acsDB;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);
            LoadClientDetails();
        }
        private void LoadClientDetails()
        {
            try
            {
                connection.Open();
                string query = @"SELECT BookingID, BookingDate, Service, HoursRendered, TotalAmount 
                             FROM Bookings 
                             WHERE ClientID = @ClientID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientID", clientID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                bookingDetailsData.DataSource = dataTable;

                // Calculate total amount
                decimal totalAmount = 0;
                foreach (DataRow row in dataTable.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["TotalAmount"]);
                }

                totalAmountLabel.Text = $"Total Amount: {totalAmount:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading client details: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
