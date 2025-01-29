using ACS_PACLAR.BookingsForms;
using ACS_PACLAR.ClientForms;
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

namespace ACS_PACLAR
{
    public partial class BookingsForm : Form
    {
        private SqlConnection connection;

        public BookingsForm()
        {
            InitializeComponent();

            string connectionString = ACSMessages.DBConnectionString;
            connection = new SqlConnection(connectionString);

            //Event Handler delete and edit button in the data grid
            this.bookingsData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookingsData_CellClick);
            //Event Handler for clientSearch Box
            bookingSearch.TextChanged += bookingSearch_TextChanged;
            bookingsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadBookings();
            LoadEditDeleteBtn();
        }

        private void LoadEditDeleteBtn()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = ACSMessages.Edit;
            editButtonColumn.Text = ACSMessages.Edit;
            editButtonColumn.UseColumnTextForButtonValue = true;
            bookingsData.Columns.Add(editButtonColumn);
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = ACSMessages.Delete;
            deleteButtonColumn.Text = ACSMessages.Delete;
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            bookingsData.Columns.Add(deleteButtonColumn);
        }

        private void bookingSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = bookingSearch.Text.Trim();
            LoadBookings(searchText);
        }

        private void LoadBookings(string searchText = "")
        {
            connection.Open();

            string query = ACSMessages.LoadBookingsData;

            if (!string.IsNullOrEmpty(searchText))
            {
                query += $" WHERE ClientName LIKE '%{searchText}%' OR BookingDate LIKE '%{searchText}%' OR TotalAmount LIKE '%{searchText}%' OR BookingReference LIKE '%{searchText}%'";
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            bookingsData.DataSource = dataTable;

            if (bookingsData.Columns[ACSMessages.BookingID] != null)
            {
                bookingsData.Columns[ACSMessages.BookingID].Visible = false;
            }

            if (bookingsData.Columns[ACSMessages.CellClickTotalAmount] != null)
            {
                bookingsData.Columns[ACSMessages.CellClickTotalAmount].DefaultCellStyle.Format = "C2";
                connection.Close();
            }
        }

        private void bookingsData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (bookingsData.Columns[e.ColumnIndex].Name == ACSMessages.Edit)
                {
                    DataGridViewRow selectedRow = bookingsData.Rows[e.RowIndex];

                    int bookingId = Convert.ToInt32(selectedRow.Cells[ACSMessages.BookingID].Value);
                    string? clientName = selectedRow.Cells[ACSMessages.CellClickClientName].Value?.ToString();
                    DateTime bookingDate = Convert.ToDateTime(selectedRow.Cells[ACSMessages.CellClickBookingDate].Value);
                    decimal totalAmount = Convert.ToDecimal(selectedRow.Cells[ACSMessages.CellClickTotalAmount].Value);

                    EditBookingForm editForm = new EditBookingForm(bookingId, clientName, bookingDate, totalAmount, connection);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadBookings();
                    }
                }
                else if (bookingsData.Columns[e.ColumnIndex].Name == ACSMessages.Delete)
                {
                    int bookingId = Convert.ToInt32(bookingsData.Rows[e.RowIndex].Cells[ACSMessages.BookingID].Value);

                    var confirmResult = MessageBox.Show(
                        ACSMessages.DeleteBookingConfirmation,
                        ACSMessages.ConfirmDelete,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirmResult == DialogResult.Yes)
                    {
                        DeleteBooking(bookingId);
                    }
                }
            }
        }
        private void DeleteBooking(int bookingId)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this booking? All associated services will also be deleted.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                connection.Open();

                string deleteServicesQuery = "DELETE FROM dbo.BookingServices WHERE BookingID = @BookingID";
                using (SqlCommand deleteServicesCommand = new SqlCommand(deleteServicesQuery, connection))
                {
                    deleteServicesCommand.Parameters.AddWithValue("@BookingID", bookingId);
                    deleteServicesCommand.ExecuteNonQuery();
                }

                string deleteBookingQuery = "DELETE FROM dbo.Bookings WHERE BookingID = @BookingID";
                using (SqlCommand deleteBookingCommand = new SqlCommand(deleteBookingQuery, connection))
                {
                    deleteBookingCommand.Parameters.AddWithValue("@BookingID", bookingId);
                    deleteBookingCommand.ExecuteNonQuery();
                }

                connection.Close();
                LoadBookings();

                MessageBox.Show(
                    "The booking and its associated services have been successfully deleted.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred while deleting the booking: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
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
