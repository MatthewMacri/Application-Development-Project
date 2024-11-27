using Car_Reservation_System.ClassesFolder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Reservation_System.ClassFiles
{
    public class Reservation
    {
        [JsonProperty("reservationid")]
        public int ReservationId { get; set; }
        [JsonProperty("car")]
        public Car Car { get; set; }
        [JsonProperty("customer")]
        public Customers Customer { get; set; }
        [JsonProperty("reservationstart")]
        public DateTime reservationStart { get; set; }
        [JsonProperty("reservationend")]
        public DateTime reservationEnd { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the Reservation class with specified reservation details.
        /// </summary>
        /// <param name="reservationId">The unique identifier for the reservation.</param>
        /// <param name="car">The car being reserved.</param>
        /// <param name="customer">The customer making the reservation.</param>
        /// <param name="reservationStart">The start date and time of the reservation.</param>
        /// <param name="reservationEnd">The end date and time of the reservation.</param>
        public Reservation(int reservationId, Car car, Customers customer, DateTime reservationStart, DateTime reservationEnd)
        {
            ReservationId = reservationId;
            Car = car;
            Customer = customer;
            this.reservationStart = reservationStart;
            this.reservationEnd = reservationEnd;
        }

        /// <summary>
        /// Confirms the reservation by setting the status to "Confirmed" and displaying a confirmation message.
        /// </summary>
        public void confirmReservation()
        {
            Status = "Confirmed";
            Console.WriteLine($"Reservation {Status}");
        }

        /// <summary>
        /// Cancels the reservation by setting the status to "Canceled" and displaying a cancellation message.
        /// </summary>
        public void cancelReservation()
        {
            Status = "Canceled";
            Console.WriteLine($"Reservation {Status}");
        }

        /// <summary>
        /// Displays detailed information about the reservation, including reservation ID, car ID, customer username,
        /// reservation start and end times, and the current reservation status.
        /// </summary>
        public void viewDetails()
        {
            Console.WriteLine($"Reservation Ticket: " +
                $"\nReservation Id: {ReservationId}, Car Id: {Car.CarId}, Reserved by: {Customer.Username}, Reservation start time: {reservationStart}, " +
                $"Reservation end time: {reservationEnd}, Status: {Status}");
        }
    }
}