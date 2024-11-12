using System.Data.SQLite;

namespace Car_Reservation_System
{
     class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
            DatabaseCar databaseCar = new DatabaseCar();
            
            using (var connection = databaseCar.GetConnection())
            {
                connection.Open();
                databaseCar.CreateCarTable(connection);
                databaseCar.CreateReservationTable(connection);
            }

        }
    }
}