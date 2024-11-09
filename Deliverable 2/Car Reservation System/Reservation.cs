using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Reservation_System
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Car Car { get; set; }
        public Customers Customer { get; set; }
        public DateTime reservationStart { get; set; }
        public DateTime reservationEnd { get; set; }
        public string Status { get; set; }

        public Reservation(int reservationId, Car car, Customers customer, DateTime reservationStart, DateTime reservationEnd)
        {
            ReservationId = reservationId;
            Car = car;
            Customer = customer;
            this.reservationStart = reservationStart;
            this.reservationEnd = reservationEnd;
        }

        public void confirmReservation() { Status = "Confirmed"; Console.WriteLine($"Reservation {Status}"); }
        public void cancelReservation() { Status = "Canceled"; Console.WriteLine($"Reservation {Status}"); }

        public void viewDetails()
        {
            Console.WriteLine($"Reservation Ticket: " +
                $"\nReservation Id: {ReservationId}, Car Id: {Car.CarId}, Reserved by: {Customer.Username}, Reservation start time: {reservationStart}, " +
                $"Rervation end time: {reservationEnd}, Status: {confirmReservation}");
        }
    }
}
