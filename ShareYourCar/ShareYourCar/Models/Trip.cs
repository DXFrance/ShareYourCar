using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareYourCar.Models
{
    public class Trip
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public Driver Driver { get; set; }
        public VehiculeType Vehicule { get; set; }

        //public string VehiculeThumbnail
        //{
        //    get
        //    {
        //        //var imageSource = ImageSource.FromResource("ShareYouCar.bike.png");
        //        //return "ShareYouCar.bike.png";
        //    }
        //}

        static public List<Trip> LoadData()
        {
            var lstTrips = new List<Trip>();

            var driver = new Driver() {
                Name = "Meeks",
                FirstName ="Joseph",
                Age = 24,
                Thumbnail = "https://acquaint.blob.core.windows.net/images/josephmeeks.jpg"
            };

            lstTrips.Add(
                new Trip()
                {
                    FromTime = DateTime.Now,
                    ToTime = DateTime.Now.AddHours(1),
                    FromLocation = "Paris",
                    ToLocation = "Antony",
                    Driver = driver,
                    Vehicule = VehiculeType.Car
                });

            lstTrips.Add(
                new Trip()
                {
                    FromTime = DateTime.Now,
                    ToTime = DateTime.Now.AddHours(3),
                    FromLocation = "Nantes",
                    ToLocation = "Bordeaux",
                    Driver = driver,
                    Vehicule = VehiculeType.Bike
                });

            lstTrips.Add(
                new Trip()
                {
                    FromTime = DateTime.Now,
                    ToTime = DateTime.Now.AddHours(3),
                    FromLocation = "Lyon",
                    ToLocation = "Marseille",
                    Driver = driver,
                    Vehicule = VehiculeType.Car
                });

            return lstTrips;
        }
    }
}
