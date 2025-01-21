using ACS_PACLAR.StringMessages;
using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace ACS_PACLAR
{
    public partial class EditClientForm : Form
    {
        private SqlConnection connection;
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public EditClientForm(int clientId, string clientName, string contactNumber, string address, string email)
        {
            InitializeComponent();
            ClientId = clientId;

            nameBox.Text = clientName;
            contactBox.Text = contactNumber;
            addressBox.Text = address;
            emailBox.Text = email;

            string connectionString = ACSMessages.DBConnectionString;
            connection = new SqlConnection(connectionString);
        }


        private void EditClientForm_Load(object sender, EventArgs e)
        {

            nameBox.Text = ClientName;
            contactBox.Text = ContactNumber;
            addressBox.Text = Address;
            emailBox.Text = Email;
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

        private void saveBtn_Click(object sender, EventArgs e)
        {

            string name = nameBox.Text.Trim();
            string contactNumber = contactBox.Text.Trim();
            string address = addressBox.Text.Trim();
            string email = emailBox.Text.Trim();

            // Validate inputs
            if (string.IsNullOrWhiteSpace(nameBox.Text) ||
                string.IsNullOrWhiteSpace(contactBox.Text) ||
                string.IsNullOrWhiteSpace(addressBox.Text) ||
                string.IsNullOrWhiteSpace(emailBox.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for confirmation before saving
            var confirmResult = MessageBox.Show("Are you sure you want to save the changes?",
                                                "Confirm Update",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.No)
            {
                return;
            }
            try
            {
                string query = ACSMessages.UpdateClientQuery;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue(ACSMessages.ClientIDPlaceholder, ClientId);
                    command.Parameters.AddWithValue(ACSMessages.NamePlaceholder, nameBox.Text.Trim());
                    command.Parameters.AddWithValue(ACSMessages.ContactPlaceholder, contactBox.Text.Trim());
                    command.Parameters.AddWithValue(ACSMessages.AddressPlaceholder, addressBox.Text.Trim());
                    command.Parameters.AddWithValue(ACSMessages.EmailPlaceholder, emailBox.Text.Trim());

                    OpenConnection();
                    command.ExecuteNonQuery();
                    CloseConnection();
                }

                MessageBox.Show("Client updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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