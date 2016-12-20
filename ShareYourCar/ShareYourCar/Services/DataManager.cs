using Microsoft.WindowsAzure.MobileServices;
using ShareYourCar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourCar.Services
{
    public partial class DataManager
    {
        static DataManager defaultInstance = new DataManager();
        MobileServiceClient client;

        IMobileServiceTable<User> userTable;
        IMobileServiceTable<Ride> rideTable;

        private DataManager()
        {
            this.client = new MobileServiceClient("http://localhost:2427/");
            this.userTable = client.GetTable<User>();
            this.rideTable = client.GetTable<Ride>();
        }

        public static DataManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public async Task<ObservableCollection<User>> GetUsersAsync()
        {
            try
            {
                IEnumerable<User> items = await userTable
                    .ToEnumerableAsync();

                return new ObservableCollection<User>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task<ObservableCollection<Ride>> GetRidesAsync()
        {
            try
            {
                IEnumerable<Ride> items = await rideTable
                    .ToEnumerableAsync();

                return new ObservableCollection<Ride>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task SaveTaskAsync(User item)
        {
            if (item.Id == null)
            {
                await userTable.InsertAsync(item);
            }
            else
            {
                await userTable.UpdateAsync(item);
            }
        }

        public async Task SaveTaskAsync(Ride item)
        {
            if (item.Id == null)
            {
                await rideTable.InsertAsync(item);
            }
            else
            {
                await rideTable.UpdateAsync(item);
            }
        }
    }
}
