using System.Data.SQLite;

namespace Car_Reservation_System.ClassFiles
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

            initDatabase();
            //DropTable(); //Drop table if needed

            ApplicationConfiguration.Initialize();
            Application.Run(new Login());

        }

        /// <summary>
        /// Initializes the Database Tables
        /// </summary>
        public static void initDatabase()
        {
            Database databaseCar = new Database();

            using (var connection = databaseCar.GetConnection())
            {
                connection.Open();
                databaseCar.CreateUsersTable(connection);
                //databaseCar.CreateCarTable(connection);
                //databaseCar.CreateReservationTable(connection);
            }
        }
        /// <summary>
        /// Drops Database Table 
        /// </summary>
        public static void DropTable()
        {
            Database databaseCar = new Database();
            using (SQLiteConnection connection = databaseCar.GetConnection())
            {
                connection.Open();

                string dropTableQuery = "DROP TABLE IF EXISTS Users";  // Change 'Users' to any existing Table

                using (SQLiteCommand command = new SQLiteCommand(dropTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}



