using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Reservation_System
{
    public class Admins : User
    {
        private int _adminId { get; set; }

        public Admins(string username, string password, string email, int adminId)
           : base(username, password, email)
        {
            _adminId = adminId;
        }

        /// <summary>
        /// Adds a new car to the database.
        /// </summary>
        public static void addCar()
        {
            Console.WriteLine("Enter Car Details:");
            Console.Write("Car ID: ");
            int carId = int.Parse(Console.ReadLine());

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Brand: ");
            string brand = Console.ReadLine();

            Console.Write("Car Type: ");
            string carType = Console.ReadLine();

            Console.Write("Available From (yyyy-MM-dd): ");
            DateTime availableFrom = DateTime.Parse(Console.ReadLine());

            Console.Write("Available To (yyyy-MM-dd): ");
            DateTime availableTo = DateTime.Parse(Console.ReadLine());

            Car car = new Car(carId, model, brand, carType, availableFrom, availableTo);

            Database db = new Database();
            db.InsertCar(car);

            Console.WriteLine("Car added successfully!");
        }

        /// <summary>
        /// Updates details of an existing car in the database.
        /// </summary>
        public void updateCar()
        {
            Database db = new Database();
            Console.Write("Enter Car ID to update: ");
            int carId = int.Parse(Console.ReadLine());

            List<Car> cars = db.GetAllCars();
            Car carToUpdate = cars.FirstOrDefault(car => car.CarId == carId);
            if (carToUpdate == null)
            {
                Console.WriteLine("Car not found!");
                return;
            }

            Console.WriteLine("Updating Car Details...");
            Console.Write("New Model (leave blank to keep current): ");
            string newModel = Console.ReadLine();
            Console.Write("New Brand (leave blank to keep current): ");
            string newBrand = Console.ReadLine();
            Console.Write("New Car Type (leave blank to keep current): ");
            string newCarType = Console.ReadLine();
            Console.Write("New Available From (yyyy-MM-dd, leave blank to keep current): ");
            string newAvailableFrom = Console.ReadLine();
            Console.Write("New Available To (yyyy-MM-dd, leave blank to keep current): ");
            string newAvailableTo = Console.ReadLine();

            if (!string.IsNullOrEmpty(newModel)) carToUpdate.Model = newModel;
            if (!string.IsNullOrEmpty(newBrand)) carToUpdate.Brand = newBrand;
            if (!string.IsNullOrEmpty(newCarType)) carToUpdate.CarType = newCarType;
            if (!string.IsNullOrEmpty(newAvailableFrom)) carToUpdate.AvailableFrom = DateTime.Parse(newAvailableFrom);
            if (!string.IsNullOrEmpty(newAvailableTo)) carToUpdate.AvailableTo = DateTime.Parse(newAvailableTo);

            using (var connection = db.GetConnection())
            {
                connection.Open();
                string updateQuery = @"UPDATE Cars SET Model = @Model, Brand = @Brand, CarType = @CarType, 
                      AvailableFrom = @AvailableFrom, AvailableTo = @AvailableTo WHERE CarId = @CarId";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Model", carToUpdate.Model);
                    command.Parameters.AddWithValue("@Brand", carToUpdate.Brand);
                    command.Parameters.AddWithValue("@CarType", carToUpdate.CarType);
                    command.Parameters.AddWithValue("@AvailableFrom", carToUpdate.AvailableFrom);
                    command.Parameters.AddWithValue("@AvailableTo", carToUpdate.AvailableTo);
                    command.Parameters.AddWithValue("@CarId", carToUpdate.CarId);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Car details updated successfully!");
        }

        /// <summary>
        /// Removes a car from the database.
        /// </summary>
        public static void removeCar()
        {
            Console.Write("Enter Car ID to remove: ");
            int carId = int.Parse(Console.ReadLine());

            Database db = new Database();
            List<Car> cars = db.GetAllCars();

            if (!cars.Any(car => car.CarId == carId))
            {
                Console.WriteLine("Car not found!");
                return;
            }

            using (var connection = db.GetConnection())
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Cars WHERE CarId = @CarId";
                using (var command = new System.Data.SQLite.SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@CarId", carId);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Car removed successfully!");
        }

        /// <summary>
        /// Lists and manages all reservations.
        /// </summary>
        public static void manageReservations()
        {
            Console.WriteLine("Fetching all reservations...");
            Database db = new Database();

            using (var connection = db.GetConnection())
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Reservations";
                using (var command = new System.Data.SQLite.SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Reservation ID: {reader.GetInt32(0)}, " +
                                              $"Car ID: {reader.GetInt32(1)}, " +
                                              $"Customer ID: {reader.GetInt32(2)}, " +
                                              $"Start: {reader.GetDateTime(3)}, " +
                                              $"End: {reader.GetDateTime(4)}, " +
                                              $"Status: {reader.GetString(5)}");
                        }
                    }
                }
            }

            Console.Write("Do you want to update any reservation status? (y/n): ");
            string choice = Console.ReadLine();
            if (choice?.ToLower() == "y")
            {
                Console.Write("Enter Reservation ID to update: ");
                int reservationId = int.Parse(Console.ReadLine());

                Console.Write("Enter new status (Confirmed/Canceled): ");
                string newStatus = Console.ReadLine();

                using (var connection = db.GetConnection())
                {
                    connection.Open();
                    string updateQuery = "UPDATE Reservations SET Status = @Status WHERE ReservationId = @ReservationId";
                    using (var command = new System.Data.SQLite.SQLiteCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Status", newStatus);
                        command.Parameters.AddWithValue("@ReservationId", reservationId);
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Reservation status updated successfully!");
            }
        }

        public override string ToString()
        {
            return $"AdminId: {_adminId}";
        }
    }
}