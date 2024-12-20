﻿using Newtonsoft.Json;
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
        /// Sets up the DatabaseCar instance to handle database operations.
        /// </summary>
        public CreateUserForm()
        {
            InitializeComponent();
            database = new Database();
        }

        /// <summary>
        /// Handles the creation of a new user when the Submit button is clicked.
        /// Validates inputs, generates a unique user ID, and inserts the new user into the Users table.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">Event data.</param>
        private void submitButton_Click(object sender, EventArgs e)
        {
                int counter = 0;
                string firstName = firstNameTextBox.Text;
                string lastName = secondNameTB.Text;
                string password = passwordTextBox.Text;

                // Check if any of the fields are empty
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int userId = randomUserId();
                MessageBox.Show("User Id: " + userId);

                try
                {
                    // Establish connection to the SQLite database
                    using (SQLiteConnection connection = database.GetConnection())
                    {
                        connection.Open();
                        database.CreateUsersTable(connection); // Ensure Users table exists

                        // Insert the new user into the Users table
                        string insertQuery = "INSERT INTO Users (UserId, Password) VALUES (@UserId, @Password)";
                        using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            command.Parameters.AddWithValue("@Password", password);

                            command.ExecuteNonQuery();
                            MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Close the form after successful creation
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle and display any database-related errors
                    MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        /// <summary>
        /// Generates a random integer to be used as a user ID, within the range 1000 to 9999.
        /// This method can be used for unique ID generation if required.
        /// </summary>
        /// <returns>A random integer between 1000 and 9999.</returns>
        private int randomUserId()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}