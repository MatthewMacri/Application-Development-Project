using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Car_Reservation_System
{
    public abstract class User
    {
        private string _username { get; set; }
        private string _password { get; set; }
        private string _email { get; set; }
        public static User LoggedInUser { get; private set; }

        public string GetUsername() => _username;
        public string GetPassword() => _password;
        public string GetEmail() => _email;

        /// <summary>
        /// This login method would take the input of the username and password and check if the user exists in the database.
        /// </summary>
        /// <param name="enteredUsername"></param>
        /// <param name="enteredPassword"></param>
        /// <returns></returns>
        public static bool Login(string enteredUsername, string enteredPassword)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "customers.json");

            if (!File.Exists(path))
            {
                Console.WriteLine("No users found. Please create a user first.");
                return false;
            }

            string json = File.ReadAllText(path);
            List<Customers> customers = JsonConvert.DeserializeObject<List<Customers>>(json);

            foreach (var customer in customers)
            {
                if (customer.Username == enteredUsername && customer.Password == enteredPassword)
                {
                    MessageBox.Show("Login successful!");
                    return true;
                }
            }

            Console.WriteLine("Login failed. Incorrect username or password.");
            return false;
        }

        /// <summary>
        /// This method would log out the user from the system.
        /// </summary>
        public static void Logout()
        {
            if (LoggedInUser != null)
            {
                Console.WriteLine($"User {LoggedInUser._username} has logged out successfully.");
                LoggedInUser = null;  // Clear the session
            }
            else
            {
                Console.WriteLine("No user is currently logged in.");
            }
        }

        /// <summary>
        ///  This method will allow the user to view their profile information.
        /// </summary>
        public void ViewProfile()
        {
            if (LoggedInUser != null)
            {
                Console.WriteLine($"Username: {LoggedInUser._username}");
                Console.WriteLine($"Email: {LoggedInUser._email}");
            }
            else
            {
                Console.WriteLine("No user is currently logged in.");
            }
        }

        public User(string username, string password, string email)
        {
            _username = username;
            _password = password;
            _email = email;
        }

        public override string ToString()
        {
            return $"Username: {_username}, Email: {_email}";
        }

    }
}
