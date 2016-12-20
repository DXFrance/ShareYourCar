using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;

namespace MobileBackend.DataObjects
{
    public class User : EntityData
    {
        public User()
        {
            this.Rides = new HashSet<Ride>();
        }

        public string Name { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Thumbnail { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Ride> Rides { get; set; }
    }
}