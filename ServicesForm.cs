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
            OpenConnection();
            string query = ACSMessages.LoadServicesData;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            servicesData.DataSource = dataTable;
            if (servicesData.Columns[ACSMessages.ServiceID] != null)
            {
                servicesData.Columns[ACSMessages.ServiceID].Visible = false;
            }

            servicesData.Columns[ACSMessages.HourlyRate].DefaultCellStyle.Format = ACSMessages.HourlyRateFormat;
        }
        private void servicesData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                servicesData.Rows[e.RowIndex].Selected = true;

                DataGridViewRow selectedRow = servicesData.Rows[e.RowIndex];

                nameBox.Text = selectedRow.Cells[ACSMessages.ServiceName].Value?.ToString();
                hourlyrateBox.Text = selectedRow.Cells[ACSMessages.HourlyRate].Value?.ToString();
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
                MessageBox.Show(ACSMessages.RequiredServiceName);
                nameBox.Focus();
                return;
            }

            if (!decimal.TryParse(hourlyRateText, out decimal hourlyRate))
            {
                MessageBox.Show(ACSMessages.InvalidHourlyRate);
                hourlyrateBox.Focus();
                return;
            }

            try
            {
                OpenConnection();

                string query = ACSMessages.AddServiceQuery;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.ServiceNamePlaceholder, name);
                    command.Parameters.AddWithValue(ACSMessages.HourlyRatePlaceholder, hourlyRate);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show(ACSMessages.ServiceAddedSuccessfully);

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
                MessageBox.Show(ACSMessages.NoServiceSelected, ACSMessages.NoSelection, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int serviceId = Convert.ToInt32(servicesData.SelectedRows[0].Cells[ACSMessages.ServiceID].Value);
            string name = nameBox.Text.Trim();
            string hourlyRateText = hourlyrateBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(ACSMessages.NoServiceName);
                nameBox.Focus();
                return;
            }

            if (!decimal.TryParse(hourlyRateText, out decimal hourlyRate))
            {
                MessageBox.Show(ACSMessages.InvalidHourlyRate);
                hourlyrateBox.Focus();
                return;
            }
            try
            {
                OpenConnection();

                string query = ACSMessages.UpdateServiceQuery;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.ServiceNamePlaceholder, name);
                    command.Parameters.AddWithValue(ACSMessages.HourlyRatePlaceholder, hourlyRate);
                    command.Parameters.AddWithValue(ACSMessages.ServiceIDPlaceholder, serviceId);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show(ACSMessages.ServiceUpdatedSuccessfully);

                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", ACSMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (servicesData.SelectedRows.Count == 0)
                {
                    MessageBox.Show(ACSMessages.NoServiceToDelete, ACSMessages.NoSelection, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int serviceId = Convert.ToInt32(servicesData.SelectedRows[0].Cells[ACSMessages.ServiceID].Value);

                var confirmResult = MessageBox.Show(ACSMessages.DeleteServiceConfirmation, ACSMessages.ConfirmDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    OpenConnection();

                    string query = ACSMessages.DeleteServiceQuery;

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(ACSMessages.ServiceIDPlaceholder, serviceId);
                        command.ExecuteNonQuery();
                    }

                    CloseConnection();

                    nameBox.Clear();
                    hourlyrateBox.Clear();
                    LoadDataGrid();

                    MessageBox.Show(ACSMessages.ServiceDeletedSuccessfully, ACSMessages.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", ACSMessages.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
