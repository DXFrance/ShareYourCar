using Microsoft.WindowsAzure.MobileServices;
using ShareYourCar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Threading;
using ShareYourCar.Services;

namespace ShareYourCar
{
    public partial class MainPage : ContentPage
    {
        TapGestureRecognizer tapImage = new TapGestureRecognizer();
        DataManager manager;

        public MainPage()
        {
            InitializeComponent();

            manager = DataManager.DefaultManager;

            tapImage.Tapped += tapImage_Tapped;
            ImageButton.GestureRecognizers.Add(tapImage);

            var addItem = new ToolbarItem()
            {
                Text = "Add",
                Icon = "pencil.png"
            };

            addItem.Clicked += (o, s) => OnAddItemClicked();
            ToolbarItems.Add(addItem);
        }

        async Task OnAddItemClicked()
        {
            var users = await manager.GetUsersAsync();

            var item = new Ride()
            {
                FromTime = DateTime.Now,
                ToTime = DateTime.Now.AddHours(1),
                FromLocation = "Paris",
                ToLocation = "Antony",
                Driver = users[0],
                MaxPassengers = 2,
                //Passengers = new List<User> { users[1], users[2] },
                Vehicule = VehiculeType.Car
            };

            await manager.SaveTaskAsync(item);

            TripsView.ItemsSource = await manager.GetRidesAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var allTrips = await Ride.LoadDataAsync();
            TripsView.ItemsSource = allTrips;
        }

        void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap   
            DisplayAlert("Alert", "This is an image button", "OK");
        }
    }
}
