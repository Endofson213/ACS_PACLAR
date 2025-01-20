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

            //Event Handler delete and edit button in the data grid
            this.clientsData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientsData_CellClick);
            
            //Event Handler for clientSearch Box
            clientSearch.TextChanged += clientSearch_TextChanged;

            LoadDataGrid();
            LoadEditDeleteBtn();
        }
        private void LoadEditDeleteBtn()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = ACSMessages.Edit;
            editButtonColumn.Text = ACSMessages.Edit;
            editButtonColumn.UseColumnTextForButtonValue = true;
            clientsData.Columns.Add(editButtonColumn);
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = ACSMessages.Delete;
            deleteButtonColumn.Text = ACSMessages.Delete;
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            clientsData.Columns.Add(deleteButtonColumn);
        }
        private void ClearBox()
        {
            nameBox.Clear();
            contactBox.Clear();
            addressBox.Clear();
            emailBox.Clear();
            addBtn.Enabled = true;
        }
        private void LoadDataGrid(string searchText = "")
        {
            connection.Open();

            // Basic query to load data
            string query = string.Format(ACSMessages.LoadClientData);

            // Filter results based on search text
            if (!string.IsNullOrEmpty(searchText))
            {
                query += $" WHERE Name LIKE '%{searchText}%' OR ContactNumber LIKE '%{searchText}%' OR Email LIKE '%{searchText}%' OR Address LIKE '%{searchText}%'";
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // Assign filtered data to DataGridView
            clientsData.DataSource = dataTable;

            // Optionally, hide ClientID column if needed
            if (clientsData.Columns[ACSMessages.ClientID] != null)
            {
                clientsData.Columns[ACSMessages.ClientID].Visible = false;
            }
            connection.Close();
        }
        private void clientSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = clientSearch.Text.Trim();

            LoadDataGrid(searchText);
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
                if (clientsData.Columns[e.ColumnIndex].Name == ACSMessages.Edit)
                {
                    // Retrieve the selected row's data
                    DataGridViewRow selectedRow = clientsData.Rows[e.RowIndex];

                    int clientId = Convert.ToInt32(selectedRow.Cells[ACSMessages.ClientID].Value);
                    string clientName = selectedRow.Cells[ACSMessages.CellClickName].Value?.ToString();
                    string contactNumber = selectedRow.Cells[ACSMessages.CellClickContactNumber].Value?.ToString();
                    string address = selectedRow.Cells[ACSMessages.CellClickAddress].Value?.ToString();
                    string email = selectedRow.Cells[ACSMessages.CellClickEmail].Value?.ToString();

                    // Open the EditClientForm and pass the data
                    EditClientForm editForm = new EditClientForm(clientId, clientName, contactNumber, address, email);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataGrid();
                    }
                }
                else if (clientsData.Columns[e.ColumnIndex].Name == ACSMessages.Delete)
                {
                    // Existing delete logic
                    int clientId = Convert.ToInt32(clientsData.Rows[e.RowIndex].Cells[ACSMessages.ClientID].Value);
                    var confirmResult = MessageBox.Show(ACSMessages.DeleteConfirmation, ACSMessages.ConfirmDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        DeleteClient(clientId);
                    }
                }
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
        private void DeleteClient(int clientId)
        {
            try
            {
                OpenConnection();
                string query = ACSMessages.DeleteClientQuery;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.ClientIDPlaceholder, clientId);
                    command.ExecuteNonQuery();
                }
                CloseConnection();
                ClearBox();
                LoadDataGrid();
                MessageBox.Show(ACSMessages.ClientDeletedSuccessfully, ACSMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", ACSMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
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

        /*
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
        */

        private void backBtn_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Hide();

        }

    }
}
