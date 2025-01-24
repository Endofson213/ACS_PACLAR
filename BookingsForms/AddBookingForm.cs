using ACS_PACLAR.StringMessages;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ACS_PACLAR.BookingsForms
{
    public partial class AddBookingForm : Form
    {
        private SqlConnection connection;

        public AddBookingForm()
        {
            InitializeComponent();
            string connectionString = ACSMessages.DBConnectionString;
            connection = new SqlConnection(connectionString);

            //Event Handlers
            serviceGridView.CellValueChanged += serviceGrid_CellValueChanged;
            serviceGridView.RowsAdded += serviceGrid_RowsAddedOrRemoved;
            serviceGridView.RowsRemoved += serviceGrid_RowsAddedOrRemoved;

            LoadClients();
            LoadServices();
        }
        private void LoadClients()
        {
            try
            {
                connection.Open();

                string query = "SELECT ClientID, ClientName FROM ClientsProfile";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Dictionary<int, string> clients = new Dictionary<int, string>();
                while (reader.Read())
                {
                    clients.Add(reader.GetInt32(0), reader.GetString(1));
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
        private void LoadServices()
        {
            connection.Open();
            try
            {
                // Add Service ComboBox Column
                DataGridViewComboBoxColumn serviceColumn = new DataGridViewComboBoxColumn
                {
                    HeaderText = "Service",
                    Name = "Service",
                    DisplayMember = "ServiceName",
                    ValueMember = "ServiceID"
                };

                string query = "SELECT ServiceID, ServiceName FROM Services";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable servicesTable = new DataTable();
                adapter.Fill(servicesTable);

                serviceColumn.DataSource = servicesTable;
                serviceGridView.Columns.Add(serviceColumn);

                // Add Hourly Rate Column
                serviceGridView.Columns.Add("HourlyRate", "Hourly Rate");

                // Add Hours Rendered Column
                serviceGridView.Columns.Add("HoursRendered", "Hours Rendered");

                // Add Subtotal Column
                serviceGridView.Columns.Add("Subtotal", "Subtotal");

                // Set ReadOnly Properties
                serviceGridView.Columns["HourlyRate"].ReadOnly = true;
                serviceGridView.Columns["Subtotal"].ReadOnly = true;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading services: " + ex.Message);
            }
        }
        private decimal GetHourlyRate(int serviceId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ACSMessages.DBConnectionString))
                {
                    connection.Open();
                    string query = "SELECT HourlyRate FROM Services WHERE ServiceID = @ServiceID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", serviceId);
                        object result = command.ExecuteScalar();
                        return result != null ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching hourly rate: " + ex.Message);
                return 0;
            }
        }

        private void ComputeTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in serviceGridView.Rows)
            {
                // Skip new row
                if (!row.IsNewRow && row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }
            totalAmountBox.Text = total.ToString("C"); // Display in currency format
        }
        private bool IsScheduleAvailable(DateTime date)
        {
            string query = "SELECT COUNT(*) FROM Bookings WHERE BookingDate = @Date";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Date", date);

            connection.Open();
            int count = (int)command.ExecuteScalar();
            connection.Close();

            return count == 0; // No conflicts if count is 0
        }
        private void serviceGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Skip processing if the event is triggered for the new row
            if (e.RowIndex >= 0 && !serviceGridView.Rows[e.RowIndex].IsNewRow)
            {
                var row = serviceGridView.Rows[e.RowIndex];

                if (serviceGridView.Columns[e.ColumnIndex].Name == "Service")
                {
                    // Get ServiceID
                    var serviceIdCell = row.Cells["Service"].Value;
                    if (serviceIdCell != null)
                    {
                        int serviceId = Convert.ToInt32(serviceIdCell);

                        // Fetch HourlyRate
                        decimal hourlyRate = GetHourlyRate(serviceId);
                        row.Cells["HourlyRate"].Value = hourlyRate;
                    }
                }

                if (serviceGridView.Columns[e.ColumnIndex].Name == "HoursRendered")
                {
                    // Calculate Subtotal
                    var hourlyRateCell = row.Cells["HourlyRate"].Value;
                    var hoursRenderedCell = row.Cells["HoursRendered"].Value;

                    if (hourlyRateCell != null && hoursRenderedCell != null &&
                        decimal.TryParse(hourlyRateCell.ToString(), out decimal hourlyRate) &&
                        decimal.TryParse(hoursRenderedCell.ToString(), out decimal hoursRendered))
                    {
                        row.Cells["Subtotal"].Value = hourlyRate * hoursRendered;
                    }
                }

                // Update Total Amount
                ComputeTotal();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clientBox.Text) || serviceGridView.Rows.Count == 0)
            {
                MessageBox.Show("Please select a client and add at least one service.");
                return;
            }

            try
            {
                // Open the connection at the start of the process
                using (SqlConnection connection = new SqlConnection(ACSMessages.DBConnectionString))
                {
                    connection.Open();

                    // Convert TotalAmount to a decimal
                    if (!decimal.TryParse(totalAmountBox.Text.Replace("₱", "").Trim(), out decimal totalAmount))
                    {
                        MessageBox.Show("Invalid total amount. Please check the data.");
                        return;
                    }

                    // Insert Booking Record
                    string bookingQuery = @"
            INSERT INTO Bookings (ClientName, BookingDate, TotalAmount)
            OUTPUT INSERTED.BookingID
            VALUES (@ClientName, @BookingDate, @TotalAmount)";
                    using (SqlCommand bookingCommand = new SqlCommand(bookingQuery, connection))
                    {
                        bookingCommand.Parameters.AddWithValue("@ClientName", clientBox.SelectedValue);
                        bookingCommand.Parameters.AddWithValue("@BookingDate", datePicker.Value);
                        bookingCommand.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        int bookingId = (int)bookingCommand.ExecuteScalar();

                        // Insert Services into BookingDetails
                        foreach (DataGridViewRow row in serviceGridView.Rows)
                        {
                            if (!row.IsNewRow && row.Cells["Service"].Value != null)
                            {
                                if (!decimal.TryParse(row.Cells["Subtotal"].Value?.ToString(), out decimal subtotal))
                                {
                                    MessageBox.Show("Invalid subtotal for a service. Please check the data.");
                                    return;
                                }

                                if (!int.TryParse(row.Cells["HoursRendered"].Value?.ToString(), out int hoursRendered))
                                {
                                    MessageBox.Show("Invalid hours rendered for a service. Please check the data.");
                                    return;
                                }

                                string detailQuery = @"
                        INSERT INTO BookingDetails (BookingID, ServiceID, HoursRendered, Subtotal, HourlyRate)
                        VALUES (@BookingID, @ServiceID, @HoursRendered, @Subtotal, @HourlyRate)";
                                using (SqlCommand command = new SqlCommand(detailQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@BookingID", bookingId);
                                    command.Parameters.AddWithValue("@ServiceID", row.Cells["Service"].Value);
                                    command.Parameters.AddWithValue("@HoursRendered", hoursRendered);
                                    command.Parameters.AddWithValue("@Subtotal", subtotal);
                                    command.Parameters.AddWithValue("@HourlyRate", row.Cells["HourlyRate"].Value);
                                    command.ExecuteNonQuery();

                                }
                                MessageBox.Show("Booking saved successfully!");
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error saving booking: " + ex.Message);
            }
        }
        private void serviceGrid_RowsAddedOrRemoved(object sender, EventArgs e)
        {
            ComputeTotal();
        }

        private void validateBtn_Click(object sender, EventArgs e)
        {
        }
    }
}