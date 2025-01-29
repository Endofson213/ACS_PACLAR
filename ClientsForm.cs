using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACS_PACLAR.ClientForms;
using ACS_PACLAR.StringMessages;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        private void LoadDataGrid(string searchText = "")
        {
            connection.Open();

            string query = string.Format(ACSMessages.LoadClientData);

            if (!string.IsNullOrEmpty(searchText))
            {
                query += $" WHERE ClientName LIKE '%{searchText}%' OR ContactNumber LIKE '%{searchText}%' OR Email LIKE '%{searchText}%' OR Address LIKE '%{searchText}%'";
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // Assign filtered data to DataGridView
            clientsData.DataSource = dataTable;

            //hide ClientID
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
        private void addBtn_Click(object sender, EventArgs e)
        {
            AddClientForm AddForm = new AddClientForm();

            if (AddForm.ShowDialog() == DialogResult.OK)
            {
                LoadDataGrid();
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
                    string? clientName = selectedRow.Cells[ACSMessages.CellClickClientName].Value?.ToString();
                    string? contactNumber = selectedRow.Cells[ACSMessages.CellClickContactNumber].Value?.ToString();
                    string? address = selectedRow.Cells[ACSMessages.CellClickAddress].Value?.ToString();
                    string? email = selectedRow.Cells[ACSMessages.CellClickEmail].Value?.ToString();

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
                    var confirmResult = MessageBox.Show(ACSMessages.DeleteClientConfirmation, ACSMessages.ConfirmDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                LoadDataGrid();
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
        private void backBtn_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Hide();
        }

    }
}
