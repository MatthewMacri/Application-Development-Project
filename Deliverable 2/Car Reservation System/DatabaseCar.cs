using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Car_Reservation_System
{
    public class DatabaseCar
    {
        private string _connecitonString;

        public DatabaseCar()
        {
            _connecitonString = @"Data Source=..\..\..\Data.db;Version=3;";
        }
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_connecitonString);
        }

        public void CreateCarTable(SQLiteConnection connection)
        {
                string createQuery = @"
                    CREATE TABLE Cars (
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
        
        public void InsertCar(Car car)
        {
            using (SQLiteConnection connection = GetConnection())
            {
                connection.Open();

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
                                reader.GetInt32(0), //CarID
                                reader.GetString(1), //Model
                                reader.GetString(2), //Brand
                                reader.GetString(3), //CarType
                                reader.GetDateTime(4), //Available From
                                reader.GetDateTime(5))); //Available To
                        }
                    }
                }
            }
            return cars;
        }

        public void CreateReservationTable(SQLiteConnection connection)
        {
            string createQuery = @"CREATE TABLE Reservations (
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
        public void InsertReservation(Reservation reservation)
        {
            using(SQLiteConnection connection = GetConnection())
            {
                connection.Open();

                string insertQuery = @" INSERT INTO Reservations (ReservationId, CarId, CustomerId, ReservationStart, ReservationEnd, Status)
                                        VALUES (@ReservationId, @CarId, @CustomerId, @ReservationStart, @ReservationEnd, @Status)
                                        ";
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
    }
}
