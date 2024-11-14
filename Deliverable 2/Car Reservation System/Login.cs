using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class Login : Form
    {
        private string connectionString = "Data Source=Data.db";

        /// <summary>
        /// Initializes a new instance of the Login form.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the CreateUserForm to allow a new user to register.
        /// Triggered when the "New User" button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void newUserButton_Click(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.ShowDialog();
        }

        /// <summary>
        /// Handles the login process when the Submit button is clicked. 
        /// It validates the input, checks the database for a matching user ID and password, 
        /// and opens the CustomerDashboard if the credentials are correct.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string userId = idTextBox.Text;
            string password = passwordTextBox.Text;

            // Check if the user ID or password fields are empty
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both ID and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Establish a connection to the SQLite database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Users WHERE UserId = @UserId AND Password = @Password";

                    // Prepare the SQL command with parameters for user ID and password
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // Check if a matching user is found
                        if (count == 1)
                        {
                            // Open the customer dashboard if login is successful
                            CustomerDashboard customerDashboard = new CustomerDashboard();
                            customerDashboard.ShowDialog();
                        }
                        else
                        {
                            // Show an error message if login fails
                            MessageBox.Show("User doesn't exist or wrong password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle and display any database-related errors
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}