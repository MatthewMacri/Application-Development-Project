using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO; // Add this import to use Path.Combine
using System.Windows.Forms;

namespace Car_Reservation_System.ClassFiles
{
    public class Database
    {
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the Database class.
        /// Sets the SQLite connection string to point to the Data.db file.
        /// </summary>
        public Database()
        {
            _connectionString = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.db")};Version=3;";
        }

        /// <summary>
        /// Creates and returns a new SQLiteConnection using the specified connection string.
        /// </summary>
        /// <returns>A new SQLiteConnection object.</returns>
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        // Cars 

        /// <summary>
        /// Creates the Cars table if it does not already exist.
        /// </summary>
        /// <param name="connection">An open SQLiteConnection to the database.</param>
        public void CreateCarTable(SQLiteConnection connection)
        {
            string createQuery = @"
                CREATE TABLE IF NOT EXISTS Cars (
                    CarId INTEGER PRIMARY KEY AUTOINCREMENT,
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
                try
                {
                    connection.Open();
                    CreateCarTable(connection); // Ensure table exists

                    string insertQuery = @"INSERT INTO Cars (Model, Brand, CarType, AvailableFrom, AvailableTo) 
                                           VALUES (@Model, @Brand, @CarType, @AvailableFrom, @AvailableTo)";
                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Model", car.Model);
                        command.Parameters.AddWithValue("@Brand", car.Brand);
                        command.Parameters.AddWithValue("@CarType", car.CarType);
                        command.Parameters.AddWithValue("@AvailableFrom", car.AvailableFrom);
                        command.Parameters.AddWithValue("@AvailableTo", car.AvailableTo);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while inserting a car: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    connection.Open();
                    string selectAllQuery = "SELECT * FROM Cars";
                    using (SQLiteCommand command = new SQLiteCommand(selectAllQuery, connection))
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
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while retrieving cars: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return cars;
        }

        // Reservations 

        /// <summary>
        /// Creates the Reservations table if it does not already exist.
        /// </summary>
        /// <param name="connection">An open SQLiteConnection to the database.</param>
        public void CreateReservationTable(SQLiteConnection connection)
        {
            string createQuery = @"
                CREATE TABLE IF NOT EXISTS Reservations (
                    ReservationId INTEGER PRIMARY KEY AUTOINCREMENT,
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
                try
                {
                    connection.Open();
                    CreateReservationTable(connection); // Ensure table exists

                    string insertQuery = @"INSERT INTO Reservations (CarId, CustomerId, ReservationStart, ReservationEnd, Status)
                                           VALUES (@CarId, @CustomerId, @ReservationStart, @ReservationEnd, @Status)";
                    using (SQLiteCommand command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CarId", reservation.Car.CarId);
                        command.Parameters.AddWithValue("@CustomerId", reservation.Customer.CustomerID);
                        command.Parameters.AddWithValue("@ReservationStart", reservation.reservationStart);
                        command.Parameters.AddWithValue("@ReservationEnd", reservation.reservationEnd);
                        command.Parameters.AddWithValue("@Status", reservation.Status);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while inserting a reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Users 

        /// <summary>
        /// Creates the Users table if it does not already exist.
        /// </summary>
        /// <param name="connection">An open SQLiteConnection to the database.</param>
        public void CreateUsersTable(SQLiteConnection connection)
        {
            string createQuery = @"
        CREATE TABLE IF NOT EXISTS Users (
            UserId INTEGER PRIMARY KEY AUTOINCREMENT,
            Username TEXT,
            Password TEXT NOT NULL,
            Email TEXT,
            Role TEXT NOT NULL
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
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while inserting a user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}