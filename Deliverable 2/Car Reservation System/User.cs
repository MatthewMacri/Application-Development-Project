using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Reservation_System
{
    public abstract class User
    {
        private string _username { get; set; }
        private string _password { get; set; }
        private string _email { get; set; }

        //TODO: Implement login method
        public static void login()
        {

        }

        //TODO: Implement logout method
        public static void logout()
        {

        }

        //TODO: Implement viewProfile method
        public static void viewProfile()
        {

        }

        public User(string username, string password, string email)
        {
            _username = username;
            _password = password;
            _email = email;
        }

        public override string ToString()
        {
            return $"Username: {_username}, Email: {_email}";
        }

    }
}
