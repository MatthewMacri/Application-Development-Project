using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class Login : Form
    {
        private string connectionString = "Data.db";

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

            // Validate user input
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both ID and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check credentials in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE UserId = @UserId AND Password = @Password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        CustomerDashboard customerDashboard = new CustomerDashboard();
                        customerDashboard.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("User doesn't exist or wrong password.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
