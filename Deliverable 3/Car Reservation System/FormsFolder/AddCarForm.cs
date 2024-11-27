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
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(carNameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid car name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string carName = carNameTextBox.Text;
            MessageBox.Show($"Car '{carName}' added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
