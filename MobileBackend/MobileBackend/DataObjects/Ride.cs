using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileBackend.DataObjects
{
    public class Ride : EntityData
    {
        public Ride()
        {
            this.Passengers = new HashSet<User>();
        }

        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        
        public User Driver { get; set; }
        public VehiculeType Vehicule { get; set; }
        public int MaxPassengers { get; set; }

        [InverseProperty("Rides")]
        public virtual ICollection<User> Passengers { get; set; }
    }
}