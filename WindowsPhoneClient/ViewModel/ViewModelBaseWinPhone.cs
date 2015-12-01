using GalaSoft.MvvmLight.Views;
using Microsoft.AspNet.SignalR.Client;
using UtilitiesPortable;
using UtilitiesPortable.SharedTypes;
using WindowsPhoneClient.Views;

namespace WindowsPhoneClient.ViewModel
{
    public class ViewModelBaseWinPhone : ViewModelBase
    {
        protected IHubProxy serverHubProxy;
        protected NavigationService navigationService;

        public ViewModelBaseWinPhone()
        {
            ConfigureRoutes();

            var hubConnection = new HubConnection("http://10.1.194.178:8081");

            serverHubProxy = hubConnection.CreateHubProxy(Constants.HUBNAME);
            hubConnection.Start().Wait();
        }

        private void ConfigureRoutes()
        {
            navigationService = new NavigationService();
            navigationService.Configure("checkIn", typeof(CheckInPage));
            navigationService.Configure("checkedInList", typeof(MainPage));
        }
    }
}