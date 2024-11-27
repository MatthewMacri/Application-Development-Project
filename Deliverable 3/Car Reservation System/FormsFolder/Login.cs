using Car_Reservation_System.ClassFiles;
using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class Login : Form
    {
        private string connectionString = "Data Source=Data.db;Version=3;";

        public Login()
        {
            InitializeComponent();
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