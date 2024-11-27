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

        private void AddCarButton_Click(object sender, EventArgs e)
        {
            // Open a form to add a new car
            using (var addCarForm = new AddCarForm())
            {
                if (addCarForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Car added successfully.");
                    RefreshCarList();
                }
            }
        }

        private void UpdateCarButton_Click(object sender, EventArgs e)
        {
            // Get the selected car from the list
            if (carListBox.SelectedItem != null)
            {
                var selectedCar = carListBox.SelectedItem.ToString();
                using (var updateCarForm = new UpdateCarForm(selectedCar))
                {
                    if (updateCarForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Car updated successfully.");
                        RefreshCarList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a car to update.");
            }
        }

        private void RemoveCarButton_Click(object sender, EventArgs e)
        {
            // Get the selected car from the list and confirm deletion
            if (carListBox.SelectedItem != null)
            {
                var selectedCar = carListBox.SelectedItem.ToString();
                var confirmResult = MessageBox.Show(
                    $"Are you sure you want to remove the car: {selectedCar}?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    RemoveCar(selectedCar);
                    MessageBox.Show("Car removed successfully.");
                    RefreshCarList();
                }
            }
            else
            {
                MessageBox.Show("Please select a car to remove.");
            }
        }

        private void ManageReservationsButton_Click(object sender, EventArgs e)
        {
            // Open the Manage Reservations form
            using (var manageReservationsForm = new ManageReservationsForm())
            {
                manageReservationsForm.ShowDialog();
            }
        }

        private void RefreshCarList()
        {
            carListBox.Items.Clear();
            var cars = GetCarList(); 
            foreach (var car in cars)
            {
                carListBox.Items.Add(car);
            }
        }

        private void RemoveCar(string car)
        {
        }

        private string[] GetCarList()
        {
            return new string[] { "Car 1", "Car 2", "Car 3" }; // Replace with actual data fetching
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
}