using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Car_Reservation_System.ClassesFolder
{
    public class Customers : User
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("CustomerID")]
        public int CustomerID { get; set; }

        [JsonProperty("ReservationHistory")]
        public List<string> ReservationHistory { get; set; }

        public Customers(string username, string password, string email, int customerID, List<string> reservationHistory)
            : base(username, password, email)
        {
            Username = username;
            Password = password;
            Email = email;
            CustomerID = customerID;
            ReservationHistory = reservationHistory ?? new List<string>();
        }

        public override string ToString()
        {
            return $"Customer ID: {CustomerID}, Username: {Username}, Email: {Email}, Reservation History: {string.Join(", ", ReservationHistory)}";
        }
        /// <summary>
        /// This methods allows the customer to make a reservation.
        /// </summary>
        /// <param name="reservationDetails"></param>
        public void MakeReservation(string reservationDetails)
        {
            ReservationHistory.Add(reservationDetails);

            UpdateCustomerData();
            Console.WriteLine("Reservation added successfully.");
        }

        /// <summary>
        /// This method allows the customer to view their reservation history.
        /// </summary>
        public void ViewReservations()
        {
            if (ReservationHistory.Count == 0)
            {
                Console.WriteLine("No reservations found.");
                return;
            }

            Console.WriteLine("Reservation History:");
            foreach (var reservation in ReservationHistory)
            {
                Console.WriteLine($"- {reservation}");
            }
        }

        /// <summary>
        /// This method will update the customer data in the JSON file.
        /// </summary>
        private void UpdateCustomerData()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "customers.json");

            List<Customers> customers;
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                customers = JsonConvert.DeserializeObject<List<Customers>>(json) ?? new List<Customers>();
            }
            else
            {
                customers = new List<Customers>();
            }

            var existingCustomer = customers.Find(c => c.CustomerID == CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.ReservationHistory = new List<string>(ReservationHistory);
            }
            else
            {
                customers.Add(this);
            }

            string updatedJson = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(path, updatedJson);
        }
    }
}
