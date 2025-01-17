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

            LoadClients();
            LoadBookings();
        }
        public static class DatabaseHelper
        {
            private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }

        private Dictionary<string, decimal> services = new Dictionary<string, decimal>
{
            { "Plumbing", 150 },
            { "Electrical", 200 },
            { "Masonry", 180 },
            { "Carpentry Works", 170 }
        };

        private void LoadClients()
        {
            try
            {
                connection.Open();
                string query = "SELECT ClientID, Name FROM ClientsProfile";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                Dictionary<int, string> clients = new Dictionary<int, string>();

                while (reader.Read())
                {
                    int clientId = reader.GetInt32(0);
                    string clientName = reader.GetString(1);
                    clients.Add(clientId, clientName);

                }

                clientBox.DataSource = new BindingSource(clients, null);
                clientBox.DisplayMember = "Value";
                clientBox.ValueMember = "Key";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error loading clients: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private void LoadBookings()
        {
            using (SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=acsDB;Trusted_Connection=True;"))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT BookingID, ClientID, BookingDate, TotalAmount FROM Bookings";
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
        private int GenerateBookingID()
        {
            int bookingID = 1; // Default ID for the first record.
            try
            {
                connection.Open();
                string query = "SELECT MAX(BookingID) FROM Bookings";
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    bookingID = Convert.ToInt32(result) + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Booking ID: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return bookingID;
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

        private void viewDetailsBtn(object sender, EventArgs e)
        {
            // Ensure a client is selected
            if (clientBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a client.");
                return;
            }

            // Ensure a booking is selected
            if (bookingsData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking.");
                return;
            }

            // Get selected client information
            var selectedClient = (KeyValuePair<int, string>)clientBox.SelectedItem;
            int clientID = selectedClient.Key;
            string clientName = selectedClient.Value;

            // Get selected booking information
            DataGridViewRow selectedRow = bookingsData.SelectedRows[0];
            int bookingID = Convert.ToInt32(selectedRow.Cells["BookingID"].Value);

            // Pass ClientID, ClientName, and BookingID to the BookingDetailsForm
            BookingDetailsForm bookingDetails = new BookingDetailsForm(clientID, clientName, bookingID);
            bookingDetails.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a client is selected
                if (clientBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a client.");
                    return;
                }

                // Get selected client details
                var selectedClient = (KeyValuePair<int, string>)clientBox.SelectedItem;
                int clientID = selectedClient.Key;

                // Get the current date for the booking date
                DateTime bookingDate = DateTime.Now;

                // Set a default total amount for the booking
                decimal totalAmount = 0;  // You can modify this later as needed

                // Open the connection
                connection.Open();

                // Insert the new booking into the database
                string query = "INSERT INTO Bookings (ClientID, BookingDate, TotalAmount) VALUES (@ClientID, @BookingDate, @TotalAmount)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientID", clientID);
                command.Parameters.AddWithValue("@BookingDate", bookingDate);
                command.Parameters.AddWithValue("@TotalAmount", totalAmount);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Booking added successfully.");
                    LoadBookings(); // Refresh the bookings list after insertion
                }
                else
                {
                    MessageBox.Show("Failed to add booking.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding booking: " + ex.Message);
            }
            finally
            {
                // Ensure the connection is closed even if an error occurs
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
