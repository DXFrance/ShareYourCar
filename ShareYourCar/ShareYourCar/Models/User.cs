using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourCar.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "birthDate")]
        public DateTime BirthDate { get; set; }
        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Version]
        public string Version { get; set; }

        public string FullDetails
        {
            get
            {
                var age = (int)(DateTime.Now - BirthDate).TotalDays / 365;
                return $"{FirstName} {Name}, {age} ans";
            }
        }
    }
}
