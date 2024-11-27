using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class AdminFormDashboard : Form
    {
        private ResourceManager _resourceManager;
        private CultureInfo _currentCulture;

        public AdminFormDashboard()
        {
            InitializeComponent();
            SetLanguage("en"); // Default language
            ApplyTranslations();
        }

        private void SetLanguage(string cultureCode)
        {
            _currentCulture = new CultureInfo(cultureCode);
            _resourceManager = new ResourceManager("Car_Reservation_System.Properties.Strings", typeof(AdminFormDashboard).Assembly);
        }

        private void ApplyTranslations()
        {
            this.Text = _resourceManager.GetString("WelcomeMessage", _currentCulture);
            addCarButton.Text = _resourceManager.GetString("AddCar", _currentCulture);
            updateCarButton.Text = _resourceManager.GetString("UpdateCar", _currentCulture);
            // Apply other translations similarly
        }

        private void LanguageChangeButton_Click(object sender, EventArgs e)
        {
            var selectedLanguage = MessageBox.Show("Switch to French?", "Change Language", MessageBoxButtons.YesNo) == DialogResult.Yes
                ? "fr"
                : "en";
            SetLanguage(selectedLanguage);
            ApplyTranslations();
}
}