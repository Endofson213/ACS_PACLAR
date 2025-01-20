using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS_PACLAR.StringMessages
{
    internal class ACSMessages
    {

        //ClientsForm
        public const string DBConnectionString = @"Server=(localdb)\mssqllocaldb;Database=acsDB;Trusted_Connection=True;";
        public const string LoadClientData = "SELECT ClientID, Name, ContactNumber, Address, Email FROM dbo.ClientsProfile";
        public const string AddClientQuery = "INSERT INTO dbo.ClientsProfile (Name, ContactNumber, Address, Email) VALUES (@Name, @ContactNumber, @Address, @Email)";
        public const string UpdateClientQuery = "UPDATE dbo.ClientsProfile SET Name = @Name, ContactNumber = @ContactNumber, Address = @Address, Email = @Email WHERE ClientID = @ClientID";
        public const string DeleteClientQuery = "DELETE FROM dbo.ClientsProfile WHERE ClientID = @ClientID";

        public const string ClientID = "ClientID";
        public const string CellClickName = "Name";
        public const string CellClickContactNumber = "ContactNumber";
        public const string CellClickAddress = "Address";
        public const string CellClickEmail = "Email";

        public const string EmptyName = "Name is required. Please enter a valid name.";
        public const string EmptyContact = "Contact number is required. Please enter a valid contact number.";
        public const string EmptyAddress = "Address is required. Please enter a valid address.";
        public const string EmptyEmail = "Email is required. Please enter a valid email.";

        public const string ClientIDPlaceholder = "@ClientID";
        public const string NamePlaceholder = "@Name";
        public const string ContactPlaceholder = "@ContactNumber";
        public const string AddressPlaceholder = "@Address";
        public const string EmailPlaceholder = "@Email";

        public const string ClientAddedSuccessfully = "Client added successfully!";
        public const string ClientUpdatedSuccessfully = "Client updated successfully!";
        public const string NoClientsSelectedToEdit = "Please select a client to edit.";
        public const string NoClientsSelectedToDelete = "Please select a client to delete.";
        public const string NoSelection = "No Selection";

        public const string DeleteConfirmation = "Are you sure you want to delete this client?";
        public const string ConfirmDelete = "Confirm Delete";
        public const string ClientDeletedSuccessfully = "Client deleted successfully.";
        public const string Success = "Success";
        public const string Edit = "Edit";
        public const string Delete = "Delete";
        public const string Error = "Error";

        //ServicesForm
        public const string LoadServicesData = "SELECT ServiceID, Name, HourlyRate FROM dbo.Services";
        public const string ServiceID = "ServiceID";
        public const string HourlyRate = "HourlyRate";

    }
}
