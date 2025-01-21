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

namespace ACS_PACLAR.ClientForms
{
    public partial class AddClientForm : Form
    {

        private SqlConnection connection;

        public AddClientForm()
        {
            InitializeComponent();
            string connectionString = ACSMessages.DBConnectionString;
            connection = new SqlConnection(connectionString);
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text.Trim();
            string contactNumber = contactBox.Text.Trim();
            string address = addressBox.Text.Trim();
            string email = emailBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(nameBox.Text) ||
                string.IsNullOrWhiteSpace(contactBox.Text) ||
                string.IsNullOrWhiteSpace(addressBox.Text) ||
                string.IsNullOrWhiteSpace(emailBox.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for confirmation before saving
            var confirmResult = MessageBox.Show("Are you sure you want to add this Client?",
                                                "Confirm Add Client",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
            if (confirmResult == DialogResult.No)
            {
                return;
            }
           try

            {
                string query = ACSMessages.AddClientQuery;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.NamePlaceholder, nameBox.Text.Trim());
                    command.Parameters.AddWithValue(ACSMessages.ContactPlaceholder, contactBox.Text.Trim());
                    command.Parameters.AddWithValue(ACSMessages.AddressPlaceholder, addressBox.Text.Trim());
                    command.Parameters.AddWithValue(ACSMessages.EmailPlaceholder, emailBox.Text.Trim());

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Client Added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
    }
    }