using ACS_PACLAR.StringMessages;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        private int selectedClientId;

        public AddBookingForm()
        {
            InitializeComponent();
            string connectionString = ACSMessages.DBConnectionString;
            connection = new SqlConnection(connectionString);


            datePicker.Value = DateTime.Now;
            datePicker.MinDate = DateTime.Today;

            //Event Handlers
            clientListView.CellClick += clientListView_CellClick;
            clientSearch.TextChanged += clientSearch_TextChanged;
            serviceBox.SelectedIndexChanged += ServiceBox_SelectedIndexChanged;
            bookingSummaryGrid.CellClick += BookingSummaryGrid_CellClick;
            datePicker.ValueChanged += DatePicker_ValueChanged;
            clientListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadClients();
            LoadServices();
            LoadBookingSummaryGrid();

        }
        private void clientSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = clientSearch.Text.Trim();
            LoadClients(searchText);
        }
        private void LoadClients(string searchText = "")
        {
            clientListView.CellClick -= clientListView_CellClick;
            connection.Open();
            string query = ACSMessages.LoadClientsData;
            if (!string.IsNullOrEmpty(searchText))
            {
                query += $" WHERE ClientName LIKE '%{searchText}%'";
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            clientListView.DataSource = dataTable;

            if (clientListView.Columns[ACSMessages.ClientID] != null)
            {
                clientListView.Columns[ACSMessages.ClientID].Visible = false;
            }
            clientListView.ClearSelection();
            clientListView.CurrentCell = null;

            connection.Close();

            clientListView.CellClick += clientListView_CellClick;
        }

        private void clientListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = clientListView.Rows[e.RowIndex];
                selectedClientId = Convert.ToInt32(row.Cells[ACSMessages.ClientID].Value);
                MessageBox.Show($"Client selected: {row.Cells[ACSMessages.ClientName].Value}");
            }
        }
        private void clientListView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !clientListView.Rows[e.RowIndex].IsNewRow)
            {
                var row = clientListView.Rows[e.RowIndex];

                if (clientListView.Columns[e.ColumnIndex].Name == "Service")
                {
                    // Get ServiceID
                    var serviceIdCell = row.Cells["Service"].Value;
                    if (serviceIdCell != null)
                    {
                        int serviceId = Convert.ToInt32(serviceIdCell);

                        decimal hourlyRate = GetHourlyRate(serviceId);
                        row.Cells["HourlyRate"].Value = hourlyRate;
                    }
                }

                if (clientListView.Columns[e.ColumnIndex].Name == "HoursRendered")
                {
                    var hourlyRateCell = row.Cells["HourlyRate"].Value;
                    var hoursRenderedCell = row.Cells["HoursRendered"].Value;

                    if (hourlyRateCell != null && hoursRenderedCell != null &&
                        decimal.TryParse(hourlyRateCell.ToString(), out decimal hourlyRate) &&
                        decimal.TryParse(hoursRenderedCell.ToString(), out decimal hoursRendered))
                    {
                        row.Cells["Subtotal"].Value = hourlyRate * hoursRendered;
                    }
                }
            }
        }
        private void LoadServices()
        {
            try
            {
                string query = ACSMessages.LoadServicesData;

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable servicesTable = new DataTable();
                adapter.Fill(servicesTable);

                DataRow blankRow = servicesTable.NewRow();
                blankRow["ServiceID"] = DBNull.Value;
                blankRow["ServiceName"] = "-Select a Service-";
                servicesTable.Rows.InsertAt(blankRow, 0);

                serviceBox.DataSource = servicesTable;
                serviceBox.DisplayMember = "ServiceName";
                serviceBox.ValueMember = "ServiceID";
                serviceBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                connection.Close();
                return 0;
            }
        }
        private void ServiceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serviceBox.SelectedValue != null && serviceBox.SelectedValue is int serviceId)
            {
                // Get the DataTable bound to the ComboBox
                DataTable servicesTable = (DataTable)serviceBox.DataSource;

                DataRow[] selectedRows = servicesTable.Select($"ServiceID = {serviceId}");
                if (selectedRows.Length > 0)
                {
                    // Retrieve the HourlyRate from the selected row
                    decimal hourlyRate = Convert.ToDecimal(selectedRows[0]["HourlyRate"]);

                    // Update the HourlyRateLabel
                    hourlyRateLabel.Text = $"Hourly Rate: {hourlyRate:C}";
                }
            }
            else
            {
                hourlyRateLabel.Text = "Hourly Rate: N/A";
            }
        }
        private void addServiceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceBox.SelectedValue == null || !int.TryParse(serviceBox.SelectedValue.ToString(), out int serviceId))
                {
                    MessageBox.Show("Please select a valid service.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int hoursRendered = (int)hoursRenderedInput.Value;
                if (hoursRendered <= 0)
                {
                    MessageBox.Show("Hours rendered must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string serviceName = serviceBox.Text;
                decimal hourlyRate = GetHourlyRate(serviceId);

                decimal subtotal = hourlyRate * hoursRendered;

                bookingSummaryGrid.Rows.Add(serviceId, serviceName, hourlyRate, hoursRendered, subtotal);

                UpdateTotalAmount();

                serviceBox.SelectedIndex = 0; // Reset to placeholder
                hoursRenderedInput.Value = 0; // Clear hours rendered input


                MessageBox.Show($"Service '{serviceName}' added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {

                MessageBox.Show($"An error occurred  while adding the service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BookingSummaryGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && bookingSummaryGrid.Columns[e.ColumnIndex].Name == "DeleteButton")
            {

                var result = MessageBox.Show("Are you sure you want to delete this service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    bookingSummaryGrid.Rows.RemoveAt(e.RowIndex);

                    UpdateTotalAmount();
                }
            }
        }

        private void UpdateTotalAmount()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in bookingSummaryGrid.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }
            totalAmountLabel.Text = $"Total Amount: {total:C}";
        }
        private void LoadBookingSummaryGrid()
        {

            bookingSummaryGrid.Columns.Clear();

            bookingSummaryGrid.Columns.Add("ServiceID", "Service ID");
            bookingSummaryGrid.Columns["ServiceID"].Visible = false;

            bookingSummaryGrid.Columns.Add("ServiceName", "Service Name");
            bookingSummaryGrid.Columns.Add("HourlyRate", "Hourly Rate");
            bookingSummaryGrid.Columns.Add("HoursRendered", "Hours Rendered");
            bookingSummaryGrid.Columns.Add("Subtotal", "Subtotal");

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Actions",
                Text = "Delete",
                UseColumnTextForButtonValue = true, // Use "Delete" as the button text
                Name = "DeleteButton",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            bookingSummaryGrid.Columns.Add(deleteButtonColumn);


            bookingSummaryGrid.ColumnHeadersVisible = true;
        }
        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = datePicker.Value.Date; // Get selected date (only the date part)

            if (IsDateOccupied(selectedDate))
            {
                MessageBox.Show("The selected date is already booked. Please choose another date.",
                                "Date Unavailable",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
        private bool IsDateOccupied(DateTime date)
        {
            string query = "SELECT COUNT(*) FROM Bookings WHERE CAST(BookingDate AS DATE) = @Date";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    connection.Close();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking booking date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return true; // Assume the date is occupied in case of an error
            }
        }
        private string GetClientNameById(int clientId)
        {
            string query = "SELECT ClientName FROM dbo.ClientsProfile WHERE ClientID = @ClientID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClientID", clientId);
                connection.Open();
                object result = command.ExecuteScalar();
                connection.Close();
                return result != null ? result.ToString() : string.Empty;
            }
        }
        private void addBookingBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate if a client is selected
                if (selectedClientId <= 0)
                {
                    MessageBox.Show("Please select a client before adding a booking.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Validate if the date is already booked
                DateTime bookingDate = datePicker.Value; // Includes both Date and Time
                if (IsDateOccupied(bookingDate.Date)) // Check only date part for conflicts
                {
                    MessageBox.Show("The selected date is already booked. Please choose another date.",
                                    "Date Unavailable",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Calculate total amount
                decimal totalAmount = 0;
                foreach (DataGridViewRow row in bookingSummaryGrid.Rows)
                {
                    if (row.Cells["Subtotal"].Value != null)
                    {
                        totalAmount += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    }
                }

                if (totalAmount <= 0)
                {
                    MessageBox.Show("Please add services to the booking before proceeding.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                int bookingId;

                string insertBookingQuery = "INSERT INTO dbo.Bookings (ClientName, BookingDate, TotalAmount) " +
                                             "VALUES (@ClientName, @BookingDate, @TotalAmount); " +
                                             "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlConnection connection = new SqlConnection(ACSMessages.DBConnectionString))
                using (SqlCommand command = new SqlCommand(insertBookingQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClientName", GetClientNameById(selectedClientId));
                    command.Parameters.AddWithValue("@BookingDate", bookingDate); // Includes Date and Time
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);

                    connection.Open();
                    bookingId = (int)command.ExecuteScalar();
                }

                string insertServiceQuery = "INSERT INTO dbo.BookingServices (BookingID, ServiceID, HoursRendered, HourlyRate, Subtotal) " +
                                             "VALUES (@BookingID, @ServiceID, @HoursRendered, @HourlyRate, @Subtotal);";

                using (SqlConnection connection = new SqlConnection(ACSMessages.DBConnectionString))
                {
                    foreach (DataGridViewRow row in bookingSummaryGrid.Rows)
                    {
                        if (row.Cells["ServiceID"].Value != null &&
                            row.Cells["HoursRendered"].Value != null &&
                            row.Cells["HourlyRate"].Value != null &&
                            row.Cells["Subtotal"].Value != null)
                        {
                            using (SqlCommand serviceCommand = new SqlCommand(insertServiceQuery, connection))
                            {
                                serviceCommand.Parameters.AddWithValue("@BookingID", bookingId);
                                serviceCommand.Parameters.AddWithValue("@ServiceID", Convert.ToInt32(row.Cells["ServiceID"].Value));
                                serviceCommand.Parameters.AddWithValue("@HoursRendered", Convert.ToDecimal(row.Cells["HoursRendered"].Value));
                                serviceCommand.Parameters.AddWithValue("@HourlyRate", Convert.ToDecimal(row.Cells["HourlyRate"].Value));
                                serviceCommand.Parameters.AddWithValue("@Subtotal", Convert.ToDecimal(row.Cells["Subtotal"].Value));

                                connection.Open();
                                serviceCommand.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                    }
                }

                MessageBox.Show("Booking and services successfully added!",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the booking: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}