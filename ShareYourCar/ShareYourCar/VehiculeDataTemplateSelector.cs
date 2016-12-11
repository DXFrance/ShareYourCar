using ShareYourCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareYourCar
{
    public class VehiculeDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate BikeTemplate { get; set; }
        public DataTemplate CarTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Trip)item).Vehicule == VehiculeType.Bike ? BikeTemplate : CarTemplate;
        }
    }
}
