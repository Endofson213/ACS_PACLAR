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
    public partial class ServicesForm : Form
    {
        private SqlConnection connection;
        public ServicesForm()
        {
            InitializeComponent();

            string connectionString = ACSMessages.DBConnectionString;
            connection = new SqlConnection(connectionString);

            //only numbers
            hourlyrateBox.KeyPress += HourlyRateBox_KeyPress;

            this.servicesData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.servicesData_CellClick);

            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            connection.Open();
            string query = ACSMessages.LoadServicesData;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            servicesData.DataSource = dataTable;
            if (servicesData.Columns[ACSMessages.ServiceID] != null)
            {
                servicesData.Columns[ACSMessages.ServiceID].Visible = false;
            }

            servicesData.Columns[ACSMessages.HourlyRate].DefaultCellStyle.Format = "N2";
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
        private void servicesData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                servicesData.Rows[e.RowIndex].Selected = true;

                DataGridViewRow selectedRow = servicesData.Rows[e.RowIndex];

                nameBox.Text = selectedRow.Cells["ServiceName"].Value?.ToString();
                hourlyrateBox.Text = selectedRow.Cells["hourlyrate"].Value?.ToString();
            }
        }
        private void HourlyRateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            if (char.IsControl(keyChar))
            {
                return;
            }

            if (char.IsDigit(keyChar))
            {
                return;
            }
            if (keyChar == '.' && !hourlyrateBox.Text.Contains('.'))
            {
                return;
            }
            e.Handled = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text.Trim();
            string hourlyRateText = hourlyrateBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Service name is required.");
                nameBox.Focus();
                return;
            }

            if (!decimal.TryParse(hourlyRateText, out decimal hourlyRate))
            {
                MessageBox.Show("Invalid hourly rate. Please enter a valid number.");
                hourlyrateBox.Focus();
                return;
            }

            try
            {
                OpenConnection();

                string query = "INSERT INTO dbo.Services (ServiceName, HourlyRate) VALUES (@ServiceName, @HourlyRate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceName", name);
                    command.Parameters.AddWithValue("@HourlyRate", hourlyRate);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show("Service added successfully!");

                nameBox.Clear();
                hourlyrateBox.Clear();

                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editBtn_Click(object sender, EventArgs e)
        {
            if (servicesData.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a service to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int serviceId = Convert.ToInt32(servicesData.SelectedRows[0].Cells["ServiceID"].Value);
            string name = nameBox.Text.Trim();
            string hourlyRateText = hourlyrateBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Service name is required.");
                nameBox.Focus();
                return;
            }

            if (!decimal.TryParse(hourlyRateText, out decimal hourlyRate))
            {
                MessageBox.Show("Invalid hourly rate. Please enter a valid number.");
                hourlyrateBox.Focus();
                return;
            }

            try
            {
                OpenConnection();

                string query = "UPDATE dbo.Services SET ServiceName = @ServiceName, HourlyRate = @HourlyRate WHERE ServiceID = @ServiceID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceName", name);
                    command.Parameters.AddWithValue("@HourlyRate", hourlyRate);
                    command.Parameters.AddWithValue("@ServiceID", serviceId);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show("Service updated successfully!");

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
                if (servicesData.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Service to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int serviceId = Convert.ToInt32(servicesData.SelectedRows[0].Cells["ServiceID"].Value);

                var confirmResult = MessageBox.Show("Are you sure you want to delete this Service?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    OpenConnection();

                    string query = "DELETE FROM dbo.Services WHERE ServiceID = @ServiceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", serviceId);
                        command.ExecuteNonQuery();
                    }

                    CloseConnection();

                    nameBox.Clear();
                    hourlyrateBox.Clear();
                    LoadDataGrid();

                    MessageBox.Show("Service deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Main MainForm = new Main();
            MainForm.Show();
            this.Hide();

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            nameBox.Clear();
            hourlyrateBox.Clear();
        }
    }
}
