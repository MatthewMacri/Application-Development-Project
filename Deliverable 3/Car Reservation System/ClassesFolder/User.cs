using Car_Reservation_System.ClassesFolder;
using Newtonsoft.Json;

public abstract class User
{
        private string _username { get; set; }
        private string _password { get; set; }
        private string _email { get; set; }

        public User(string username, string password, string email)
        {
            _username = username;
            _password = password;
            _email = email;
        }

        // Getter methods...
        public string GetUsername() => _username;
        public string GetPassword() => _password;
        public string GetEmail() => _email;

        public static bool Login(string enteredUsername, string enteredPassword)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "customers.json");

        if (!File.Exists(path))
        {
            Console.WriteLine("No users found. Please create a user first.");
            return false;
        }

        string json = File.ReadAllText(path);
        List<Customers> customers = JsonConvert.DeserializeObject<List<Customers>>(json);

        foreach (var customer in customers)
        {
            if (customer.Username == enteredUsername && customer.Password == enteredPassword)
            {
                MessageBox.Show("Login successful!");
                return true;
            }
        }

        Console.WriteLine("Login failed. Incorrect username or password.");
        return false;
    }
}