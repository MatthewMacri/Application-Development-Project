using Car_Reservation_System.ClassFiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class CreateUserForm : Form
    {
        private Database database;

        /// <summary>
        /// Initializes a new instance of the CreateUserForm.
        /// Sets up the Database instance to handle database operations.
        /// </summary>
        public CreateUserForm()
        {
            InitializeComponent();
            database = new Database();

            // Populate the roleComboBox with options
            roleComboBox.Items.Add("Admin");
            roleComboBox.Items.Add("Customer");
            roleComboBox.SelectedIndex = 0; // Default to "Customer"
        }

        /// <summary>
        /// Handles the creation of a new user when the Submit button is clicked.
        /// Validates inputs, generates a unique user ID, and inserts the new user into the Users table.
        /// </summary>
        private void submitButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = secondNameTB.Text;
            string password = passwordTextBox.Text;
            string role = roleComboBox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userId = randomUserId();
            try
            {
                using (SQLiteConnection connection = database.GetConnection())
                {
                    connection.Open();
                    database.CreateUsersTable(connection);

                    string insertQuery = "INSERT INTO Users (UserId, Username, Password, Role) VALUES (@UserId, @Username, @Password, @Role)";
                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Username", $"{firstName} {lastName}");
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Role", role);

                        command.ExecuteNonQuery();
                        MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Generates a random integer to be used as a user ID, within the range 1000 to 9999.
        /// This method can be used for unique ID generation if required.
        /// </summary>
        private int randomUserId()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}