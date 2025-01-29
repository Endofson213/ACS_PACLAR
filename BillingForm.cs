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
    public partial class BillingForm : Form
    {
        private string connectionString = ACSMessages.DBConnectionString;

        public BillingForm()
        {
            InitializeComponent();

            billingSearch.TextChanged += inventorySearch_TextChanged;
            billingData.CellContentClick += BillingData_CellContentClick;
            billingData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadBillingData();
            LoadPaidBtn();
        }

        private void BillingData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = billingData.Columns[e.ColumnIndex].Name;
                string billingID = billingData.Rows[e.RowIndex].Cells[ACSMessages.BillingID]?.Value?.ToString();
                string currentStatus = billingData.Rows[e.RowIndex].Cells["PaymentStatus"]?.Value?.ToString();

                if (!string.IsNullOrEmpty(billingID) && columnName == ACSMessages.Paid)
                {
                    if (currentStatus == "Paid")
                    {
                        MessageBox.Show("This client is already marked as paid.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DialogResult dialogResult = MessageBox.Show("Mark this client as paid?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdatePaymentStatus(billingID, "Paid");
                    }
                }
            }
        }

        private void UpdatePaymentStatus(string billingID, string newStatus)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE dbo.Billing SET PaymentStatus = @PaymentStatus, PaymentDate = @PaymentDate WHERE BillingID = @BillingID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PaymentStatus", newStatus);
                    command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                    command.Parameters.AddWithValue("@BillingID", billingID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                LoadBillingData();

                MessageBox.Show($"Payment status updated to '{newStatus}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating payment status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaidBtn()
        {
            if (!billingData.Columns.Contains(ACSMessages.Paid))
            {
                DataGridViewButtonColumn paidButtonColumn = new DataGridViewButtonColumn
                {
                    Name = ACSMessages.Paid,
                    Text = ACSMessages.Paid,
                    UseColumnTextForButtonValue = true
                };
                billingData.Columns.Add(paidButtonColumn);
            }
        }

        private void inventorySearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = billingSearch.Text.Trim();
            LoadBillingData(searchText);
        }

        private void LoadBillingData(string searchText = "")
        {
            try
            {
                string query = "SELECT BillingID, BillingReference, ClientName, TotalAmount, PaymentStatus, BillingDate, PaymentDate FROM dbo.Billing";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        query += $" WHERE ClientName LIKE '%{searchText}%' OR TotalAmount LIKE '%{searchText}%' OR PaymentStatus LIKE '%{searchText}%' OR BillingDate LIKE '%{searchText}%'";
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable billingTable = new DataTable();
                        adapter.Fill(billingTable);
                        billingData.DataSource = billingTable;

                        if (billingData.Columns[ACSMessages.BillingID] != null)
                        {
                            billingData.Columns[ACSMessages.BillingID].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading billing data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
