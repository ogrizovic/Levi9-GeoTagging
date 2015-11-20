using GalaSoft.MvvmLight.Views;
using Microsoft.AspNet.SignalR.Client;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WindowsPhoneClient.Helpers;
using WindowsPhoneClient.Views;

namespace WindowsPhoneClient
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected IHubProxy serverHubProxy;
        protected NavigationService navigationService;

        public ViewModelBase()
        {
            ConfigureRoutes();

            var hubConnection = new HubConnection("http://localhost:8081");

            serverHubProxy = hubConnection.CreateHubProxy(Constants.HUBNAME);
            hubConnection.Start().Wait();
        }

        private void ConfigureRoutes()
        {
            navigationService = new NavigationService();
            navigationService.Configure("checkIn", typeof(CheckInPage));
            navigationService.Configure("checkedInList", typeof(MainPage));
        }

        public void Set<T>(ref T oldValue, T newValue, [CallerMemberName]string propertyName = "")
        {
            if (oldValue == null || !oldValue.Equals(newValue))
            {
                oldValue = newValue;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}