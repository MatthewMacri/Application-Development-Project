using Car_Reservation_System.ClassFiles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
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

            // Subscribe to the LanguageManager's event
            LanguageManager.LanguageChanged += UpdateLanguage;

            // Populate the roleComboBox with options
            roleComboBox.Items.Add("Admin");
            roleComboBox.Items.Add("Customer");
            roleComboBox.SelectedIndex = 0; // Default to "Customer"

            // Set the initial language
            UpdateLanguage();
        }

        /// <summary>
        /// Handles the creation of a new user when the Submit button is clicked.
        /// Validates inputs, generates a unique user ID, and inserts the new user into the Users table.
        /// </summary>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Gather input from text fields and combo box
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string password = passwordTextBox.Text;
            string role = roleComboBox.SelectedItem?.ToString();

            // Validate input fields
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate a random User ID
            int userId = new Random().Next(1000, 9999);

            try
            {
                using (SQLiteConnection connection = database.GetConnection())
                {
                    connection.Open();
                    database.CreateUsersTable(connection); // Ensure the Users table exists

                    // Insert the new user into the database
                    string insertQuery = "INSERT INTO Users (UserId, Username, Password, Role) VALUES (@UserId, @Username, @Password, @Role)";
                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Username", $"{firstName} {lastName}");
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Role", role);

                        command.ExecuteNonQuery();
                    }
                }

                // Display the generated User ID
                MessageBox.Show($"User created successfully! Your ID is: {userId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally clear the form or close it
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle database errors
                MessageBox.Show($"An error occurred while creating the user: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Generates a random integer to be used as a user ID, within the range 1000 to 9999.
        /// </summary>
        private int RandomUserId()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

        /// <summary>
        /// Updates the form's language based on the current culture.
        /// </summary>
        private void UpdateLanguage()
        {
            // Load the resource manager and current culture
            var rm = Car_Reservation_System.Properties.Resource.ResourceManager;
            var culture = LanguageManager.CurrentCulture;

            // Debug logging
            Console.WriteLine($"Culture: {culture.Name}");
            Console.WriteLine($"LastNameLabel Text: {rm.GetString("LastNameLabel", culture)}");

            // Update UI components with localized text
            creatingUserLabel.Text = rm.GetString("CreatingUserLabel", culture);
            firstNameLabel.Text = rm.GetString("FirstNameLabel", culture);
            lastNameLabel.Text = rm.GetString("LastNameLabel", culture) ?? "Last Name :"; // Fallback if null
            passwordLabel.Text = rm.GetString("PasswordLabel", culture);
            roleLabel.Text = rm.GetString("RoleLabel", culture);
            submitButton.Text = rm.GetString("SubmitButton", culture);
            cancelButton.Text = rm.GetString("CancelButton", culture);
        }

        /// <summary>
        /// Unsubscribes from the LanguageManager event to prevent memory leaks.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            LanguageManager.LanguageChanged -= UpdateLanguage;
            base.OnFormClosed(e);
        }

        /// <summary>
        /// Handles the Cancel button click event. Closes the form without saving.
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Simply close the form
        }
    }
}