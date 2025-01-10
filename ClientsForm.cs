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
    public partial class ClientsForm : Form
    {

        private SqlConnection connection;


        public ClientsForm()
        {
            InitializeComponent();

            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=acsDB;Trusted_Connection=True;";
            connection = new SqlConnection(connectionString);

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
            string query = "SELECT ClientID, Name, ContactNumber, Address FROM [dbo].[Table]";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            clientsData.DataSource = dataTable;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string contactNumber = contactBox.Text;
            string address = addressBox.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name is required. Please enter a valid name.");
                return;
            }

            try
            {
                OpenConnection();
                string query = "INSERT INTO [dbo].[Table] (Name, ContactNumber, Address) VALUES (@Name, @ContactNumber, @Address)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@ContactNumber", string.IsNullOrEmpty(contactNumber) ? (object)DBNull.Value : contactNumber);
                    command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(address) ? (object)DBNull.Value : address);

                    command.ExecuteNonQuery();
                }

                CloseConnection();

                MessageBox.Show("Client added successfully!");

                nameBox.Clear();
                contactBox.Clear();
                addressBox.Clear();
                LoadDataGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {

        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
