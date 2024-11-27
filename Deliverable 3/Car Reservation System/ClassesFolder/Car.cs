using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Reservation_System.ClassFiles
{
    public class Car
    {
        [JsonProperty("carid")]
        public int CarId { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("cartype")]
        public string CarType { get; set; }
        [JsonProperty("availablefrom")]
        public DateTime AvailableFrom { get; set; }
        [JsonProperty("availableto")]
        public DateTime AvailableTo { get; set; }

        public Car(int carId, string model, string brand, string carType, DateTime availableFrom, DateTime availableTo)
        {
            CarId = carId;
            Model = model;
            Brand = brand;
            CarType = carType;
            AvailableFrom = availableFrom;
            AvailableTo = availableTo;
        }
        /// <summary>
        /// If current time is bigger than Available From and current time is smaller than Available To 
        /// </summary>
        /// <returns>If car is available or not</returns>
        public bool isAvailable()
        {
            DateTime currentTime = DateTime.Now;
            return currentTime > AvailableFrom && currentTime < AvailableTo;
        }

        public void getCarDetails()
        {
            Console.WriteLine($"Car Id: {CarId}, Model: {Model}, Brand: {Brand}, Type: {CarType}");
        }
    }

}
