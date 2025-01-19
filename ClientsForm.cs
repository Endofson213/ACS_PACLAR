using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACS_PACLAR.StringMessages;
using Microsoft.Data.SqlClient;

namespace ACS_PACLAR
{
    public partial class ClientsForm : Form
    {
        private SqlConnection connection;

        private void ClientsForm_Load(object sender, EventArgs e) { }
        public ClientsForm()
        {
            InitializeComponent();

            string connectionString = (ACSMessages.DBConnectionString);
            connection = new SqlConnection(connectionString);

            this.clientsData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsData_CellClick);

            LoadDataGrid();
        }
        private void ClearBox()
        {
            nameBox.Clear();
            contactBox.Clear();
            addressBox.Clear();
            emailBox.Clear();
            addBtn.Enabled = true;
        }
        private void LoadDataGrid()
        {
            connection.Open();
            string query = string.Format(ACSMessages.LoadClientData);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            clientsData.DataSource = dataTable;
            if (clientsData.Columns[ACSMessages.ClientID] != null)
            {
                clientsData.Columns[ACSMessages.ClientID].Visible = false;
            }
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
        private void clientsData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clientsData.Rows[e.RowIndex].Selected = true;

                DataGridViewRow selectedRow = clientsData.Rows[e.RowIndex];

                nameBox.Text = selectedRow.Cells[ACSMessages.CellClickName].Value?.ToString();
                contactBox.Text = selectedRow.Cells[ACSMessages.CellClickContactNumber].Value?.ToString();
                addressBox.Text = selectedRow.Cells[ACSMessages.CellClickAddress].Value?.ToString();
                emailBox.Text = selectedRow.Cells[ACSMessages.CellClickEmail].Value?.ToString();
                addBtn.Enabled = false;
            }
        }
        private void ClientsData_SelectionChanged(object sender, EventArgs e)
        {
            if (clientsData.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = clientsData.SelectedRows[0];

                nameBox.Text = selectedRow.Cells[ACSMessages.CellClickName].Value?.ToString();
                contactBox.Text = selectedRow.Cells[ACSMessages.CellClickContactNumber].Value?.ToString();
                addressBox.Text = selectedRow.Cells[ACSMessages.CellClickAddress].Value?.ToString();
                emailBox.Text = selectedRow.Cells[ACSMessages.CellClickEmail].Value?.ToString();
                addBtn.Enabled = false;
            }
            else
            {
                ClearBox();
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
                MessageBox.Show(ACSMessages.EmptyName);
                nameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(contactNumber))
            {
                MessageBox.Show(ACSMessages.EmptyContact);
                contactBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show(ACSMessages.EmptyAddress);
                addressBox.Focus();
                return;
            }
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show(ACSMessages.EmptyEmail);
                emailBox.Focus();
                return;
            }
            try
            {
                OpenConnection();

                string query =(ACSMessages.AddClientQuery);

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.NamePlaceholder, name);
                    command.Parameters.AddWithValue(ACSMessages.ContactPlaceholder, contactNumber);
                    command.Parameters.AddWithValue(ACSMessages.AddressPlaceholder, address);
                    command.Parameters.AddWithValue(ACSMessages.EmailPlaceholder, email);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show(ACSMessages.ClientAddedSuccessfully);

                ClearBox();
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (clientsData.SelectedRows.Count == 0)
            {
                MessageBox.Show(ACSMessages.NoClientsSelectedToEdit, ACSMessages.NoSelection, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int clientId = Convert.ToInt32(clientsData.SelectedRows[0].Cells[ACSMessages.ClientID].Value);

            string name = nameBox.Text.Trim();
            string contactNumber = contactBox.Text.Trim();
            string address = addressBox.Text.Trim();
            string email = emailBox.Text.Trim();


            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(ACSMessages.EmptyName);
                nameBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(contactNumber))
            {
                MessageBox.Show(ACSMessages.EmptyContact);
                contactBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show(ACSMessages.EmptyAddress);
                addressBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show(ACSMessages.EmptyEmail);
                emailBox.Focus();
                return;
            }

            try
            {
                OpenConnection();
                string query = ACSMessages.UpdateClientQuery;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.ClientID, clientId);
                    command.Parameters.AddWithValue(ACSMessages.NamePlaceholder, name);
                    command.Parameters.AddWithValue(ACSMessages.ContactPlaceholder, contactNumber);
                    command.Parameters.AddWithValue(ACSMessages.AddressPlaceholder, address);
                    command.Parameters.AddWithValue(ACSMessages.EmailPlaceholder, email);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show(ACSMessages.ClientUpdatedSuccessfully);

                ClearBox();
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
                    MessageBox.Show(ACSMessages.NoClientsSelectedToDelete, ACSMessages.NoSelection, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int clientId = Convert.ToInt32(clientsData.SelectedRows[0].Cells[ACSMessages.ClientID].Value);

                var confirmResult = MessageBox.Show(ACSMessages.DeleteConfirmation, ACSMessages.ConfirmDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    OpenConnection();

                    string query = ACSMessages.DeleteClientQuery;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(ACSMessages.ClientIDPlaceHolder, clientId);
                        command.ExecuteNonQuery();
                    }

                    CloseConnection();
                    ClearBox();
                    LoadDataGrid();

                    MessageBox.Show(ACSMessages.ClientDeletedSuccessfully, ACSMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }
        private void backBtn_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Hide();

        }

    }
}
