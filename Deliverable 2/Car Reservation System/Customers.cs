using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Car_Reservation_System
{
    public class Customers : User
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }  // Changed to string for the password

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("CustomerID")]
        public int CustomerID { get; set; }

        [JsonProperty("ReservationHistory")]
        public List<string> ReservationHistory { get; set; }

        // Constructor with parameters
        public Customers(string username, string password, string email, int customerID, List<string> reservationHistory)
            : base(username, password, email)
        {
            Username = username;
            Password = password;
            Email = email;
            CustomerID = customerID;
            ReservationHistory = reservationHistory;
        }

        // Override ToString for a readable representation
        public override string ToString()
        {
            return $"Customer ID: {CustomerID}, Username: {Username}, Email: {Email}, Reservation History: {string.Join(", ", ReservationHistory)}";
        }

        // Methods (placeholders)
        public static void MakeReservation()
        {
            // Placeholder for makeReservation implementation
        }

        public static void ViewReservations()
        {
            // Placeholder for viewReservations implementation
        }
    }
}
