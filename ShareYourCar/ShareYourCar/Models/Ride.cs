using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using ShareYourCar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourCar.Models
{
    public class Ride
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "fromTime")]
        public DateTime FromTime { get; set; }
        [JsonProperty(PropertyName = "toTime")]
        public DateTime ToTime { get; set; }
        [JsonProperty(PropertyName = "fromLocation")]
        public string FromLocation { get; set; }
        [JsonProperty(PropertyName = "toLocation")]
        public string ToLocation { get; set; }
        [JsonProperty(PropertyName = "driver")]
        public User Driver { get; set; }
        [JsonProperty(PropertyName = "maxPassengers")]
        public int MaxPassengers { get; set; }
        [JsonProperty(PropertyName = "vehicule")]
        public VehiculeType Vehicule { get; set; }
        [JsonProperty(PropertyName = "passengers")]
        public List<User> Passengers { get; set; }

        [Version]
        public string Version { get; set; }

        static public async Task<ObservableCollection<Ride>> LoadDataAsync()
        {
            return await DataManager.DefaultManager.GetRidesAsync();
        }
    }
}
