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
    public partial class EditBookingForm : Form
    {
        private int bookingId;
        private SqlConnection connection;
        public EditBookingForm(int bookingId, string clientName, DateTime bookingDate, decimal totalAmount, SqlConnection connection)
        {
            InitializeComponent();

            this.bookingId = bookingId;
            this.connection = connection;

            // Populate the form fields with the passed data
            clientNameBox.Text = clientName;
            datePicker.Value = bookingDate;
            totalAmountBox.Text = totalAmount.ToString();

            serviceBox.SelectedIndexChanged += serviceBox_SelectedIndexChanged;
            bookingSummaryGrid.CellContentClick += bookingSummaryGrid_CellContentClick;


            LoadServices();
            LoadBookingSummary(bookingId);
        }
        private void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        private void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        private void LoadServices()
        {
            try
            {
                OpenConnection();
                string query = "SELECT ServiceID, ServiceName, HourlyRate FROM dbo.Services;";
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
            finally
            {
                CloseConnection();
            }
        }
        private void serviceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (serviceBox.SelectedValue != null && int.TryParse(serviceBox.SelectedValue.ToString(), out int serviceId))
                {
                    decimal hourlyRate = GetHourlyRate(serviceId);
                    hourlyRateLabel.Text = $"Hourly Rate: {hourlyRate:C}";
                }
                else
                {
                    hourlyRateLabel.Text = "Hourly Rate: N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating hourly rate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookingSummary(int bookingId)
        {
            OpenConnection();
            try
            {
                bookingSummaryGrid.Columns.Add("ServiceID", "Service ID");
                bookingSummaryGrid.Columns["ServiceID"].Visible = false;

                bookingSummaryGrid.Columns.Add("ServiceName", "Service Name");
                bookingSummaryGrid.Columns.Add("HourlyRate", "Hourly Rate");
                bookingSummaryGrid.Columns.Add("HoursRendered", "Hours Rendered");
                bookingSummaryGrid.Columns.Add("Subtotal", "Subtotal");

                // Add the "Delete" button column
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Actions",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true, // Use "Delete" as the button text
                    Name = "DeleteButton",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                };
                bookingSummaryGrid.Columns.Add(deleteButtonColumn);

                // Adjust styling (optional)
                bookingSummaryGrid.DefaultCellStyle.Font = new Font("Arial", 12);
                bookingSummaryGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
                bookingSummaryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                // Query to fetch BookingServices details
                string query = @"
    SELECT 
        bs.ServiceID, 
        s.ServiceName, 
        s.HourlyRate, 
        bs.HoursRendered, 
        (s.HourlyRate * bs.HoursRendered) AS Subtotal
    FROM 
        BookingServices bs
    INNER JOIN 
        Services s ON bs.ServiceID = s.ServiceID
    WHERE 
        bs.BookingID = @BookingID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable bookingDetailsTable = new DataTable();
                    adapter.Fill(bookingDetailsTable);

                    // Add rows to the grid
                    foreach (DataRow row in bookingDetailsTable.Rows)
                    {
                        bookingSummaryGrid.Rows.Add(
                            row["ServiceID"],
                            row["ServiceName"],
                            row["HourlyRate"],
                            row["HoursRendered"],
                            row["Subtotal"]
                        );
                        bookingSummaryGrid.Columns["HourlyRate"].DefaultCellStyle.Format = "N2";
                        bookingSummaryGrid.Columns["HoursRendered"].DefaultCellStyle.Format = "N0";
                        bookingSummaryGrid.Columns["Subtotal"].DefaultCellStyle.Format = "N2";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading booking summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }
        private void bookingSummaryGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked column is the "Delete" button column
            if (e.ColumnIndex == bookingSummaryGrid.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                try
                {
                    // Get the ServiceID and BookingID from the row
                    var serviceId = bookingSummaryGrid.Rows[e.RowIndex].Cells["ServiceID"].Value;
                    if (serviceId == null)
                    {
                        MessageBox.Show("Invalid service. Unable to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int serviceID = Convert.ToInt32(serviceId);

                    // Confirm the deletion
                    var result = MessageBox.Show("Are you sure you want to delete this service?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Delete the record from the database
                        DeleteServiceFromBooking(bookingId, serviceID);

                        // Remove the row from the grid
                        bookingSummaryGrid.Rows.RemoveAt(e.RowIndex);

                        // Update the total amount
                        UpdateTotalAmount();

                        MessageBox.Show("Service deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DeleteServiceFromBooking(int bookingId, int serviceId)
        {
            try
            {
                OpenConnection();

                string deleteQuery = "DELETE FROM BookingServices WHERE BookingID = @BookingID AND ServiceID = @ServiceID";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingId);
                    command.Parameters.AddWithValue("@ServiceID", serviceId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting service from database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }

        private void SaveBookingServices()
        {
            try
            {
                OpenConnection();

                string mergeQuery = @"
            MERGE INTO BookingServices AS target
            USING (VALUES (@BookingID, @ServiceID, @HoursRendered, @HourlyRate, @Subtotal)) 
                AS source (BookingID, ServiceID, HoursRendered, HourlyRate, Subtotal)
            ON target.BookingID = source.BookingID AND target.ServiceID = source.ServiceID
            WHEN MATCHED THEN
                UPDATE SET 
                    HoursRendered = source.HoursRendered,
                    HourlyRate = source.HourlyRate,
                    Subtotal = source.Subtotal
            WHEN NOT MATCHED THEN
                INSERT (BookingID, ServiceID, HoursRendered, HourlyRate, Subtotal)
                VALUES (source.BookingID, source.ServiceID, source.HoursRendered, source.HourlyRate, source.Subtotal);";

                foreach (DataGridViewRow row in bookingSummaryGrid.Rows)
                {
                    if (row.Cells["ServiceID"].Value != null && row.Cells["HoursRendered"].Value != null)
                    {
                        using (SqlCommand command = new SqlCommand(mergeQuery, connection))
                        {
                            command.Parameters.AddWithValue("@BookingID", bookingId); // Pass the booking ID
                            command.Parameters.AddWithValue("@ServiceID", Convert.ToInt32(row.Cells["ServiceID"].Value)); // Service ID
                            command.Parameters.AddWithValue("@HoursRendered", Convert.ToDecimal(row.Cells["HoursRendered"].Value)); // Hours rendered
                            command.Parameters.AddWithValue("@HourlyRate", Convert.ToDecimal(row.Cells["HourlyRate"].Value)); // Hourly rate
                            command.Parameters.AddWithValue("@Subtotal", Convert.ToDecimal(row.Cells["Subtotal"].Value)); // Subtotal

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving booking services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }


        private decimal GetHourlyRate(int serviceId)
        {
            OpenConnection();
            try
            {
                string query = "SELECT HourlyRate FROM Services WHERE ServiceID = @ServiceID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceID", serviceId);

                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToDecimal(result) : 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching hourly rate: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                CloseConnection();
            }

        }
        private decimal CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in bookingSummaryGrid.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }
            }
            return total;
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
            totalAmountBox.Text = $"{total:N2}";
        }
        private void addServiceBtn_Click(object sender, EventArgs e)
        {
            OpenConnection();
            try
            {
                // Validate if a service is selected
                if (serviceBox.SelectedValue == null || !int.TryParse(serviceBox.SelectedValue.ToString(), out int serviceId))
                {
                    MessageBox.Show("Please select a valid service.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate if hours rendered is a valid decimal number
                double hoursRendered = (double)hoursRenderedInput.Value;
                if (hoursRendered <= 0)
                {
                    MessageBox.Show("Hours rendered must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fetch service details
                string serviceName = serviceBox.Text; // Name of the selected service
                decimal hourlyRate = GetHourlyRate(serviceId); // Fetch hourly rate of the selected service
                decimal subtotal = hourlyRate * (decimal)hoursRendered;

                // Add the service details to the booking summary grid
                bookingSummaryGrid.Rows.Add(serviceId, serviceName, hourlyRate, hoursRendered, subtotal);

                UpdateTotalAmount();

                serviceBox.SelectedIndex = 0;
                hoursRenderedInput.Value = 0;

                MessageBox.Show($"Service '{serviceName}' added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }
        private void saveBookingBtn_Click(object sender, EventArgs e)
        {
            OpenConnection();
            try
            {
                // Calculate the total amount
                decimal totalAmount = CalculateTotalAmount();

                // Update the main booking details
                string updateBookingQuery = @"
        UPDATE dbo.Bookings
        SET BookingDate = @BookingDate, TotalAmount = @TotalAmount
        WHERE BookingID = @BookingID;";

                using (SqlCommand command = new SqlCommand(updateBookingQuery, connection))
                {
                    command.Parameters.AddWithValue("@BookingID", bookingId);
                    command.Parameters.AddWithValue("@BookingDate", datePicker.Value);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);

                    command.ExecuteNonQuery();
                }

                // Save the associated services
                SaveBookingServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving booking changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
                MessageBox.Show("Booking updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}