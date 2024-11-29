<<<<<<< Updated upstream
﻿using Car_Reservation_System.ClassFiles;
using System;
using System.Data.Entity;
=======
﻿using System;
>>>>>>> Stashed changes
using System.Data.SQLite;
using System.Windows.Forms;
using Car_Reservation_System.ClassesFolder;

namespace Car_Reservation_System
{
    public partial class Login : Form
    {
<<<<<<< Updated upstream
        private string connectionString = "Data Source=Data.db;Version=3;";
=======
        private Database database;
>>>>>>> Stashed changes

        public Login()
        {
            InitializeComponent();
<<<<<<< Updated upstream
=======

            LanguageManager.LanguageChanged += UpdateLanguage;

            UpdateLanguage();
            database = new Database();

        }

        private void UpdateLanguage()
        {
            var rm = Car_Reservation_System.Properties.Resource.ResourceManager;
            var culture = LanguageManager.CurrentCulture;

            // Update UI components with localized text
            label1.Text = rm.GetString("LoginScreenLabel", culture);
            label2.Text = rm.GetString("IdLabel", culture);
            label3.Text = rm.GetString("PasswordLabel", culture);
            button1.Text = culture.Name == "fr-FR" ? "Anglais" : "French";

            if (SubmitButton != null)
                SubmitButton.Text = rm.GetString("SubmitButton", culture);

            if (newUserButton != null)
                newUserButton.Text = rm.GetString("NewUserButton", culture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Toggle language
            LanguageManager.CurrentCulture = LanguageManager.CurrentCulture.Name == "en-US"
                ? new System.Globalization.CultureInfo("fr-FR")
                : new System.Globalization.CultureInfo("en-US");
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string username = idTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection connection = database.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();
                            if (role == "Admin")
                            {
                                // Open Admin Dashboard
                                AdminFormDashboard adminDashboard = new AdminFormDashboard();
                                adminDashboard.Show();
                            }
                            else if (role == "Customer")
                            {
                                // Open Customer Dashboard
                                CustomerDashboard customerDashboard = new CustomerDashboard();
                                customerDashboard.Show();
                            }
                            else
                            {
                                MessageBox.Show("Unknown role. Contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            this.Close(); // Close the login form
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
>>>>>>> Stashed changes
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.ShowDialog();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string userId = idTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both ID and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Check user role in the database
                    string query = "SELECT Role FROM Users WHERE UserId = @UserId AND Password = @Password";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Password", password);

                        object roleObj = command.ExecuteScalar();

                        if (roleObj != null)
                        {
                            string role = roleObj.ToString();
                            if (role == "admin")
                            {
                                // Open Admin Dashboard
                                AdminFormDashboard adminDashboard = new AdminFormDashboard();
                                adminDashboard.ShowDialog();
                            }
                            else if (role == "customer")
                            {
                                // Open Customer Dashboard
                                CustomerDashboard customerDashboard = new CustomerDashboard();
                                customerDashboard.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Invalid user role.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("User does not exist or incorrect password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}