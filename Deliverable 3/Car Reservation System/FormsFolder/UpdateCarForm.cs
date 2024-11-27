using System;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class UpdateCarForm : Form
    {
        private string selectedCar;

        public UpdateCarForm(string car)
        {
            selectedCar = car;
            InitializeComponent();
            carNameTextBox.Text = selectedCar; // Set the initial value of the text box
        }

        // Event handler for the Save button click
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(carNameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid car name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the car name logic (stubbed for demonstration)
            string updatedCarName = carNameTextBox.Text;
            MessageBox.Show($"Car '{updatedCarName}' updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Close the form after updating
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Event handler for the Cancel button click
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Close the form without making changes
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}