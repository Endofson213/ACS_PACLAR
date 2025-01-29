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
    public partial class EditInventoryForm : Form
    {

        private int inventoryId { get; set; }
        public string ToolName { get; set; }
        public string ServiceName { get; set; }
        public int QuantityAvailable { get; set; }

        private SqlConnection connection;
        public EditInventoryForm(int inventoryId, string ToolName, string ServiceName, int QuantityAvailable, SqlConnection connection)
        {
            InitializeComponent();

            this.inventoryId = inventoryId;
            this.connection = connection;

            // Populate ComboBox before selecting the item
            PopulateServiceBox();

            // Populate the form fields with the passed data
            nameBox.Text = ToolName;
            quantityBox.Value = QuantityAvailable;

            // Set selected value in ComboBox
            if (serviceBox.Items.Contains(ServiceName))
            {
                serviceBox.SelectedItem = ServiceName;
            }
            else
            {
                serviceBox.Text = ServiceName; // Set the text if it's not in the list
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

        private void PopulateServiceBox()
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

                        while (reader.Read())
                        {
                            serviceBox.Items.Add(reader["ServiceName"].ToString());
                        }
                    }
                }
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate Inputs
                if (string.IsNullOrWhiteSpace(nameBox.Text) || serviceBox.SelectedItem == null || quantityBox.Value <= 0)
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newToolName = nameBox.Text.Trim();
                string newServiceName = serviceBox.SelectedItem.ToString();
                int newQuantity = (int)quantityBox.Value;

                OpenConnection();

                // Update SQL Query
                string query = @"UPDATE Inventory 
                         SET ToolName = @ToolName, 
                             ServiceName = @ServiceName, 
                             QuantityAvailable = @QuantityAvailable 
                         WHERE InventoryId = @InventoryId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ToolName", newToolName);
                    command.Parameters.AddWithValue("@ServiceName", newServiceName);
                    command.Parameters.AddWithValue("@QuantityAvailable", newQuantity);
                    command.Parameters.AddWithValue("@InventoryId", inventoryId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Inventory updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update inventory. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}