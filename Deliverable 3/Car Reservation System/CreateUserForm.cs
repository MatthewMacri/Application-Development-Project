using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public partial class CreateUserForm : Form
    {
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            List<Customers> customersList = new List<Customers>();
            customersList.Add(new Customers(firstNameTextBox.Text + secondNameTB.Text, passwordTextBox.Text, firstNameTextBox.Text + lastNameLabel.Text + "@gmail.com",randomUserId(),new List<string>())); 
            userIdLabel.Text = "User ID: " + randomUserId();
            userIdLabel.Visible = true;


            var json = JsonConvert.SerializeObject(customersList, Formatting.Indented);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "customers.json");
            File.WriteAllText(path, json);
            MessageBox.Show($"Customer list saved to: {Path.GetFullPath(path)}");

        }

        //TODO: Document this method
        private int randomUserId()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
