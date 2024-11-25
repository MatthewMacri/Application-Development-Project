using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Car_Reservation_System
{
    public class Database
    {
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the DatabaseCar class.
        /// Sets the SQLite connection string to point to the Data.db file.
        /// </summary>
        public Database()
        {
            _connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}Data.db;Version=3;";
        }

        /// <summary>
        /// Creates and returns a new SQLiteConnection using the specified connection string.
        /// </summary>
        /// <returns>A new SQLiteConnection object.</returns>
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        //Cars 

        /// <summary>
        /// Creates the Cars table if it does not already exist.
        /// </summary>
        /// <param name="connection">An open SQLiteConnection to the database.</param>
        public void CreateCarTable(SQLiteConnection connection)
        {
            string createQuery = @"
                CREATE TABLE IF NOT EXISTS Cars (
                    CarId INTEGER PRIMARY KEY,
                    Model TEXT,
                    Brand TEXT,
                    CarType TEXT,
                    AvailableFrom DATETIME,
                    AvailableTo DATETIME
                )";

            using (SQLiteCommand command = new SQLiteCommand(createQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Inserts a new car record into the Cars table.
        /// Ensures that the Cars table exists before attempting to insert.
        /// </summary>
        /// <param name="car">The Car object containing car details to be inserted.</param>
        public void InsertCar(Car car)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                connection.Open();
                CreateCarTable(connection); // Ensure table exists

                string insertQuery = @"INSERT INTO Cars (CarId, Model, Brand, CarType, AvailableFrom, AvailableTo) 
                    VALUES (@CarId, @Model, @Brand, @CarType, @AvailableFrom, @AvailableTo)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@CarId", car.CarId);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@Brand", car.Brand);
                    command.Parameters.AddWithValue("@CarType", car.CarType);
                    command.Parameters.AddWithValue("@AvailableFrom", car.AvailableFrom);
                    command.Parameters.AddWithValue("@AvailableTo", car.AvailableTo);

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Retrieves all car records from the Cars table and returns them as a list of Car objects.
        /// </summary>
        /// <returns>A list of Car objects representing all cars in the Cars table.</returns>
        public List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            using (SQLiteConnection connection = GetConnection())
            {
                connection.Open();
                string selectallQuery = "SELECT * FROM Cars";
                using (SQLiteCommand command = new SQLiteCommand(selectallQuery, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car(
                                reader.GetInt32(0), // CarId
                                reader.GetString(1), // Model
                                reader.GetString(2), // Brand
                                reader.GetString(3), // CarType
                                reader.GetDateTime(4), // AvailableFrom
                                reader.GetDateTime(5)  // AvailableTo
                            ));
                        }
                    }
                }
            }
            return cars;
        }

        /// <summary>
        /// Creates the Reservations table if it does not already exist.
        /// </summary>
        /// <param name="connection">An open SQLiteConnection to the database.</param>
        public void CreateReservationTable(SQLiteConnection connection)
        {
            string createQuery = @"
                CREATE TABLE IF NOT EXISTS Reservations (
                    ReservationId INTEGER PRIMARY KEY,
                    CarId INTEGER,
                    CustomerId INTEGER,
                    ReservationStart DATETIME,
                    ReservationEnd DATETIME,
                    Status TEXT,
                    FOREIGN KEY (CarId) REFERENCES Cars(CarId)
                )";

            using (SQLiteCommand command = new SQLiteCommand(createQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Inserts a new reservation record into the Reservations table.
        /// Ensures that the Reservations table exists before attempting to insert.
        /// </summary>
        /// <param name="reservation">The Reservation object containing reservation details to be inserted.</param>
        public void InsertReservation(Reservation reservation)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                connection.Open();
                CreateReservationTable(connection); // Ensure table exists

                string insertQuery = @"INSERT INTO Reservations (ReservationId, CarId, CustomerId, ReservationStart, ReservationEnd, Status)
                                       VALUES (@ReservationId, @CarId, @CustomerId, @ReservationStart, @ReservationEnd, @Status)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);
                    command.Parameters.AddWithValue("@CarId", reservation.Car.CarId);
                    command.Parameters.AddWithValue("@CustomerId", reservation.Customer.CustomerID);
                    command.Parameters.AddWithValue("@ReservationStart", reservation.reservationStart);
                    command.Parameters.AddWithValue("@ReservationEnd", reservation.reservationEnd);
                    command.Parameters.AddWithValue("@Status", reservation.Status);

                    command.ExecuteNonQuery();
                }
            }
        }

        //Users 

        /// <summary>
        /// Creates the Users table if it does not already exist.
        /// </summary>
        /// <param name="connection">An open SQLiteConnection to the database.</param>
        public void CreateUsersTable(SQLiteConnection connection)
        {
            string createQuery = @"
            CREATE TABLE IF NOT EXISTS Users (
                UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                Username TEXT NOT NULL UNIQUE,
                Password TEXT NOT NULL,
                Email TEXT NOT NULL UNIQUE
            )";

            using (SQLiteCommand command = new SQLiteCommand(createQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Inserts a new user record into the Users table.
        /// Ensures that the Users table exists before attempting to insert.
        /// </summary>
        /// <param name="user">The User object containing user details to be inserted.</param>
        public void InsertUser(User user)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                connection.Open();
                CreateUsersTable(connection); // Ensure table exists

                string insertQuery = @"INSERT INTO Users (Username, Password, Email)
                                       VALUES (@Username, @Password, @Email)";
                using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.GetUsername());
                    command.Parameters.AddWithValue("@Password", user.GetPassword());
                    command.Parameters.AddWithValue("@Email", user.GetEmail());

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
