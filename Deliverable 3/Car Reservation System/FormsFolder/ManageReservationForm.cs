using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class ManageReservationsForm : Form
    {
        private const string _connectionString = "Data Source=Data.db;Version=3;";

        public ManageReservationsForm()
        {
            InitializeComponent();
        }

        // Event handler for Save button click
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string reservationDetails = reservationTextBox.Text;

            if (string.IsNullOrWhiteSpace(reservationDetails))
            {
                MessageBox.Show("Please enter reservation details.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveReservationToDatabase(reservationDetails);

            MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reservationTextBox.Clear();
        }

        private void SaveReservationToDatabase(string details)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Reservations (Details) VALUES (@Details)";
                    SQLiteCommand command = new SQLiteCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@Details", details);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Cancel button click
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Close the form without making any changes
            this.Close();
        }
    }
}