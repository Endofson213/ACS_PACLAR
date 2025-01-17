using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ACS_PACLAR
{
    public partial class ClientsForm : Form
    {

        private SqlConnection connection;


        public ClientsForm()
        {
            InitializeComponent();

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=acsDB;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);

            this.clientsData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsData_CellClick);

            LoadDataGrid();
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
        private void LoadDataGrid()
        {
            connection.Open();
            string query = "SELECT ClientID, Name, ContactNumber, Address, Email FROM dbo.ClientsProfile";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            clientsData.DataSource = dataTable;
        }
        private void clientsData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clientsData.Rows[e.RowIndex].Selected = true;

                DataGridViewRow selectedRow = clientsData.Rows[e.RowIndex];

                clientBox.Text = selectedRow.Cells["ClientID"].Value?.ToString();
                nameBox.Text = selectedRow.Cells["Name"].Value?.ToString();
                contactBox.Text = selectedRow.Cells["ContactNumber"].Value?.ToString();
                addressBox.Text = selectedRow.Cells["Address"].Value?.ToString();
                emailBox.Text = selectedRow.Cells["Email"].Value?.ToString();
            }
        }
        private void ClientsData_SelectionChanged(object sender, EventArgs e)
        {

            if (clientsData.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = clientsData.SelectedRows[0];


                clientBox.Text = selectedRow.Cells["ClientID"].Value?.ToString();
                nameBox.Text = selectedRow.Cells["Name"].Value?.ToString();
                contactBox.Text = selectedRow.Cells["ContactNumber"].Value?.ToString();
                addressBox.Text = selectedRow.Cells["Address"].Value?.ToString();
                emailBox.Text = selectedRow.Cells["Email"].Value?.ToString();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text.Trim();
            string contactNumber = contactBox.Text.Trim();
            string address = addressBox.Text.Trim();
            string email = emailBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required. Please enter a valid name.");
                nameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(contactNumber))
            {
                MessageBox.Show("Contact number is required. Please enter a valid contact number.");
                contactBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address is required. Please enter a valid address.");
                addressBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is required. Please enter a valid email.");
                emailBox.Focus();
                return;
            }

            try
            {
                OpenConnection();
                string query = "INSERT INTO dbo.ClientsProfile (Name, ContactNumber, Address, Email) VALUES (@Name, @ContactNumber, @Address, @Email)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ContactNumber", contactNumber);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show("Client added successfully!");

                clientBox.Clear();
                nameBox.Clear();
                contactBox.Clear();
                addressBox.Clear();
                emailBox.Clear();

                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (clientsData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the ClientID of the selected row
            int clientId = Convert.ToInt32(clientsData.SelectedRows[0].Cells["ClientID"].Value);

            // Get the data from the textboxes
            string name = nameBox.Text.Trim();
            string contactNumber = contactBox.Text.Trim();
            string address = addressBox.Text.Trim();
            string email = emailBox.Text.Trim();


            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required. Please enter a valid name.");
                nameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(contactNumber))
            {
                MessageBox.Show("Contact number is required. Please enter a valid contact number.");
                contactBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address is required. Please enter a valid address.");
                addressBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is required. Please enter a valid email.");
                emailBox.Focus();
                return;
            }

            try
            {
                OpenConnection();
                string query = "UPDATE dbo.ClientsProfile SET Name = @Name, ContactNumber = @ContactNumber, Address = @Address, Email = @Email WHERE ClientID = @ClientID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientID", clientId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ContactNumber", contactNumber);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Email", email);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show("Client updated successfully!");

                LoadDataGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientsData.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a client to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int clientId = Convert.ToInt32(clientsData.SelectedRows[0].Cells["ClientID"].Value);

                var confirmResult = MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    OpenConnection();

                    string query = "DELETE FROM dbo.ClientsProfile WHERE ClientID = @ClientID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClientID", clientId);
                        command.ExecuteNonQuery();
                    }


                    CloseConnection();

                    clientBox.Clear();
                    nameBox.Clear();
                    contactBox.Clear();
                    addressBox.Clear();
                    emailBox.Clear();
                    LoadDataGrid();

                    MessageBox.Show("Client deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClientsForm_Load(object sender, EventArgs e)
        {

        }

        private void backBtn(object sender, EventArgs e)
        {
            Main MainForm = new Main();

            MainForm.Show();

            this.Hide();

        }
    }
}
