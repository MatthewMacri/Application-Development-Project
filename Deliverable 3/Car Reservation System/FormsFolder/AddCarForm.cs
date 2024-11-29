using System;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class AddCarForm : Form
    {
        // UI Controls
        private TextBox carNameTextBox;
        private Label carNameLabel;
        private Button addButton;
        private Button cancelButton;

        public AddCarForm()
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
            if (carNameLabel != null)
                carNameLabel.Text = rm.GetString("CarNameLabel", culture);

            if (addButton != null)
                addButton.Text = rm.GetString("AddCarButton", culture);

            if (cancelButton != null)
                cancelButton.Text = rm.GetString("CancelButton", culture);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(carNameTextBox.Text))
            {
                MessageBox.Show(
                    LanguageManager.CurrentCulture.Name == "fr-FR"
                        ? "Veuillez entrer un nom de voiture valide."
                        : "Please enter a valid car name.",
                    LanguageManager.CurrentCulture.Name == "fr-FR" ? "Erreur d'entrée" : "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            string carName = carNameTextBox.Text;
            MessageBox.Show(
                LanguageManager.CurrentCulture.Name == "fr-FR"
                    ? $"Voiture '{carName}' ajoutée avec succès."
                    : $"Car '{carName}' added successfully.",
                LanguageManager.CurrentCulture.Name == "fr-FR" ? "Succès" : "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Unsubscribe from the LanguageManager's event to prevent memory leaks
            LanguageManager.LanguageChanged -= UpdateLanguage;
            base.OnFormClosed(e);
        }
    }
}