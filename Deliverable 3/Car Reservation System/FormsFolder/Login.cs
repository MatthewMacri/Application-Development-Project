using System;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Subscribe to the LanguageManager's event
            LanguageManager.LanguageChanged += UpdateLanguage;

            // Initialize the form with the current language
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
            // Handle submit logic (e.g., user authentication)
            MessageBox.Show("Submit button clicked! Implement authentication logic here.");
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