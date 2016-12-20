using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using MobileBackend.DataObjects;
using MobileBackend.Models;
using Owin;

namespace MobileBackend
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new MobileServiceInitializer());

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            User user1 = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Rousseau",
                FirstName = "Michel",
                BirthDate = new DateTime(1977, 06, 29),
                Email = "mirousse@microsoft.com",
                Thumbnail = "https://acquaint.blob.core.windows.net/images/josephmeeks.jpg"
            };

            User user2 = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Pertus",
                FirstName = "Sébastien",
                BirthDate = new DateTime(1977, 06, 29),
                Email = "spertus@microsoft.com",
                Thumbnail = "https://acquaint.blob.core.windows.net/images/josephmeeks.jpg"
            };

            User user3 = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Rousset",
                FirstName = "David",
                BirthDate = new DateTime(1977, 06, 29),
                Email = "davrous@microsoft.com",
                Thumbnail = "https://acquaint.blob.core.windows.net/images/josephmeeks.jpg"
            };

            context.Set<User>().Add(user1);
            context.Set<User>().Add(user2);
            context.Set<User>().Add(user3);

            List<Ride> rides = new List<Ride>
            {
                new Ride
                {
                    Id = Guid.NewGuid().ToString(),
                    FromTime = DateTime.Now,
                    ToTime = DateTime.Now.AddHours(1),
                    FromLocation = "Paris",
                    ToLocation = "Antony",
                    Driver = user3,
                    MaxPassengers = 2,
                    Passengers = new List<User> { user1, user2 },
                    Vehicule = VehiculeType.Car
                },
                new Ride
                {
                    Id = Guid.NewGuid().ToString(),
                    FromTime = DateTime.Now,
                    ToTime = DateTime.Now.AddHours(3),
                    FromLocation = "Nantes",
                    ToLocation = "Bordeaux",
                    Driver = user1,
                    MaxPassengers = 1,
                    Passengers = new List<User> { user3 },
                    Vehicule = VehiculeType.Bike
                },
                new Ride
                {
                    Id = Guid.NewGuid().ToString(),
                    FromTime = DateTime.Now,
                    ToTime = DateTime.Now.AddHours(3),
                    FromLocation = "Lyon",
                    ToLocation = "Marseille",
                    Driver = user1,
                    Passengers = new List<User> { user2, user3 },
                    MaxPassengers = 3,
                    Vehicule = VehiculeType.Car
                }
            };

            foreach (Ride ride in rides)
            {
                context.Set<Ride>().Add(ride);
            }

            base.Seed(context);
        }
    }
}

