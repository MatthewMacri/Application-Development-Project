using System;
using System.Data.SQLite;
using System.Windows.Forms;
using Car_Reservation_System.ClassFiles;

namespace Car_Reservation_System
{
    public partial class Login : Form
    {
        private Database database;
        public Login()
        {
            InitializeComponent();

            LanguageManager.LanguageChanged += UpdateLanguage;
            database = new Database();

            UpdateLanguage();
        }

        private void UpdateLanguage()
        {
            // Load the resource manager and current culture
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
            // Get user input from text fields
            string userId = idTextBox.Text; // TextBox for user ID
            string password = passwordTextBox.Text; // TextBox for password

            // Validate input fields
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both User ID and Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SQLiteConnection connection = database.GetConnection())
                {
                    connection.Open();

                    // Query to check user credentials
                    string query = "SELECT Role FROM Users WHERE UserId = @UserId AND Password = @Password";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@Password", password);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            // Open the appropriate dashboard based on the role
                            if (role == "Admin")
                            {
                                AdminFormDashboard adminDashboard = new AdminFormDashboard();
                                adminDashboard.Show();
                                this.Hide();
                            }
                            else if (role == "Customer")
                            {
                                CustomerDashboard customerDashboard = new CustomerDashboard();
                                customerDashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Unknown role. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid User ID or Password. Please try again.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void newUserButton_Click(object sender, EventArgs e)
        {
            // Open the CreateUserForm dialog
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.ShowDialog();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Unsubscribe from the LanguageManager's event to prevent memory leaks
            LanguageManager.LanguageChanged -= UpdateLanguage;
            base.OnFormClosed(e);
        }
    }
}