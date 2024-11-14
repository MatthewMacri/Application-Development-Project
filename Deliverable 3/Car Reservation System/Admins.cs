using System;
using System.Collections.Generic;
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

        //TODO: Implement addCar method
        public static void addCar()
        {

        }

        //TODO: Implement updateCar method
        public static void updateCar()
        {

        }

        //TODO: Implement removeCar method
        public static void removeCar()
        {
            
        }

        //TODO: Implement manageReservations method
        public static void manageReservations()
        {

        }

        public override string ToString()
        {
            return $"AdminId: {_adminId}";
        }
    }
}
