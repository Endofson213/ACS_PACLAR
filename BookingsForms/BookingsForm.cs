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
            LoadBookings();
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

            string query = string.Format(ACSMessages.LoadBookingsData);

            if (!string.IsNullOrEmpty(searchText))
            {
                query += $" WHERE ClientName LIKE '%{searchText}%' OR BookingDate LIKE '%{searchText}%' OR TotalAmount LIKE '%{searchText}%' OR CreatedAt LIKE '%{searchText}%'";
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // Assign filtered data to DataGridView
            bookingsData.DataSource = dataTable;

            //hide ClientID
            if (bookingsData.Columns[ACSMessages.BookingsID] != null)
            {
                bookingsData.Columns[ACSMessages.BookingsID].Visible = false;
            }
            connection.Close();
        }
       
        private void bookingsData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (bookingsData.Columns[e.ColumnIndex].Name == ACSMessages.Edit)
                {
                    // Retrieve the selected row's data
                    DataGridViewRow selectedRow = bookingsData.Rows[e.RowIndex];

                    int clientId = Convert.ToInt32(selectedRow.Cells[ACSMessages.ClientID].Value);
                    string? clientName = selectedRow.Cells[ACSMessages.CellClickClientName].Value?.ToString();
                    string? contactNumber = selectedRow.Cells[ACSMessages.CellClickContactNumber].Value?.ToString();
                    string? address = selectedRow.Cells[ACSMessages.CellClickAddress].Value?.ToString();
                    string? email = selectedRow.Cells[ACSMessages.CellClickEmail].Value?.ToString();

                    // Open the EditClientForm and pass the data
                    EditClientForm editForm = new EditClientForm(clientId, clientName, contactNumber, address, email);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadBookings();
                    }
                }
                else if (bookingsData.Columns[e.ColumnIndex].Name == ACSMessages.Delete)
                {
                    // Existing delete logic
                    int clientId = Convert.ToInt32(bookingsData.Rows[e.RowIndex].Cells[ACSMessages.ClientID].Value);
                    var confirmResult = MessageBox.Show(ACSMessages.DeleteConfirmation, ACSMessages.ConfirmDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        DeleteClient(clientId);
                    }
                }
            }
        }
        private void DeleteClient(int clientId)
        {
            try
            {
                connection.Open();

                string query = ACSMessages.DeleteClientQuery;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.ClientIDPlaceholder, clientId);
                    command.ExecuteNonQuery();
                }

                connection.Close();
                LoadBookings();
                MessageBox.Show(ACSMessages.ClientDeletedSuccessfully, ACSMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", ACSMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
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
