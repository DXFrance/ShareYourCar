using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourCar.Models
{
    public class Driver
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Thumbnail { get; set; }

        public string FullDetails
        {
            get
            {
                return $"{FirstName} {Name}, {Age} ans";
            }
        }
    }
}
