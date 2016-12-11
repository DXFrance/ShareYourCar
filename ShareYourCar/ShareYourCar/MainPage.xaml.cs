using ShareYourCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShareYourCar
{
    public partial class MainPage : ContentPage
    {
        List<Trip> allTrips = Trip.LoadData();
        TapGestureRecognizer tapImage = new TapGestureRecognizer();

        public MainPage()
        {
            InitializeComponent();
            TripsView.ItemsSource = allTrips;

            tapImage.Tapped += tapImage_Tapped;
            ImageButton.GestureRecognizers.Add(tapImage);
        }

        void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap   
            DisplayAlert("Alert", "This is an image button", "OK");
        }
    }
}
