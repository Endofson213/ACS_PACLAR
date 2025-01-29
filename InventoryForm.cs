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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ACS_PACLAR
{
    public partial class InventoryForm : Form
    {
        private SqlConnection connection;
        public InventoryForm()

        {
            InitializeComponent();

            string connectionString = ACSMessages.DBConnectionString;
            connection = new SqlConnection(connectionString);

            inventorySearch.TextChanged += inventorySearch_TextChanged;
            this.inventoryData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventoryData_CellClick);

            LoadServiceBox();
            LoadDataGrid();
            LoadEditDeleteBtn();
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
        private void LoadEditDeleteBtn()
        {
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.Name = ACSMessages.Edit;
            editButtonColumn.Text = ACSMessages.Edit;
            editButtonColumn.UseColumnTextForButtonValue = true;
            inventoryData.Columns.Add(editButtonColumn);
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = ACSMessages.Delete;
            deleteButtonColumn.Text = ACSMessages.Delete;
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            inventoryData.Columns.Add(deleteButtonColumn);
        }

        private void inventorySearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = inventorySearch.Text.Trim();
            LoadDataGrid(searchText);
        }

        private void LoadDataGrid(string searchText = "")
        {
            string query = ACSMessages.LoadInventoryData;
            OpenConnection();

            if (!string.IsNullOrEmpty(searchText))
            {
                query += $" WHERE ToolName LIKE '%{searchText}%' OR ServiceName LIKE '%{searchText}%'";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            inventoryData.DataSource = dataTable;
            if (inventoryData.Columns[ACSMessages.InventoryID] != null)
            {
                inventoryData.Columns[ACSMessages.InventoryID].Visible = false;
            }
            CloseConnection();
        }
        private void LoadServiceBox()
        {
            try
            {
                OpenConnection();

                string query = "SELECT ServiceName FROM dbo.Services";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        serviceBox.Items.Clear();
                        serviceBox.Items.Add("-- Select a Service --");
                        serviceBox.SelectedIndex = 0;
                        while (reader.Read())
                        {
                            string serviceName = reader["ServiceName"].ToString();
                            serviceBox.Items.Add(serviceName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while populating services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
        }
        private void inventoryData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (inventoryData.Columns[e.ColumnIndex].Name == ACSMessages.Edit)
                {
                    DataGridViewRow selectedRow = inventoryData.Rows[e.RowIndex];

                    int inventoryId = Convert.ToInt32(selectedRow.Cells[ACSMessages.InventoryID].Value);
                    string? ToolName = selectedRow.Cells[ACSMessages.CellClickToolName].Value?.ToString();
                    string? ServiceName = selectedRow.Cells[ACSMessages.CellClickServiceName].Value?.ToString();
                    int QuantityAvailable = Convert.ToInt32(selectedRow.Cells[ACSMessages.QuantityAvailable].Value);

                    // Open the EditClientForm and pass the data
                    EditInventoryForm editForm = new EditInventoryForm(inventoryId, ToolName, ServiceName, QuantityAvailable, connection);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataGrid();
                    }

                }
                else if (inventoryData.Columns[e.ColumnIndex].Name == ACSMessages.Delete)
                {
                    // Existing delete logic
                    int inventoryId = Convert.ToInt32(inventoryData.Rows[e.RowIndex].Cells[ACSMessages.InventoryID].Value);
                    var confirmResult = MessageBox.Show(ACSMessages.DeleteToolConfirmation, ACSMessages.ConfirmDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        DeleteTool(inventoryId);
                    }
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                string toolName = nameBox.Text.Trim();
                string serviceName = serviceBox.Text.Trim();
                int quantityAvailable;

                // Check if service is selected properly
                if (serviceBox.SelectedIndex == 0 || string.IsNullOrEmpty(serviceName) || serviceName == "-- Select a Service --")
                {
                    MessageBox.Show("Please select a valid service.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(quantityBox.Text.Trim(), out quantityAvailable))
                {
                    MessageBox.Show("Please enter a valid quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(toolName))
                {
                    MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"INSERT INTO Inventory (ToolName, ServiceName, QuantityAvailable)
                         VALUES (@ToolName, @ServiceName, @QuantityAvailable)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ToolName", toolName);
                    command.Parameters.AddWithValue("@ServiceName", serviceName);
                    command.Parameters.AddWithValue("@QuantityAvailable", quantityAvailable);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Tool added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add tool. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void DeleteTool(int inventoryId)
        {
            try
            {
                OpenConnection();

                string query = ACSMessages.DeleteInventoryQuery;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.InventoryIDPlaceholder, inventoryId);
                    command.ExecuteNonQuery();
                }

                CloseConnection();
                LoadDataGrid();
                MessageBox.Show(ACSMessages.ToolDeletedSuccessfully, ACSMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void backBtn_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Hide();

        }
    }
}
