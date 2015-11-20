using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UtilitiesPortable.CommonExtensions;
using UtilitiesPortable;
using UtilitiesPortable.SharedModels;
using UtilitiesPortable.SharedCommands;
using UtilitiesPortable.SharedTypes;

namespace ClientLocationBroadcastingTerminal
{
    public class MainWindowViewModel : ViewModelBase
    {

        #region fields
        private IHubProxy serverHubProxy;
        private ObservableCollection<Sensor> oldClients = new ObservableCollection<Sensor>();
        #endregion

        #region constructors
        public MainWindowViewModel()
        {
            SearchBoxGotFocusCommand = new RelayCommand<UIElement>(SearchboxGotFocusHandler);
            GetClientsLocationCommand = new RelayCommand<Sensor>(GetSensorsLocation);
            SearchCommand = new RelayCommand<string>(SearchFilter);
            SetupHubConnection();
            SearchBoxLostFocusCommand = new RelayCommand<UIElement>(SearchboxLostFocusHandler);
        }
        #endregion constructors

        #region properties
        private ObservableCollection<Sensor> sensors;
        public ObservableCollection<Sensor> Sensors
        {
            get
            {
                return sensors;
            }
            set
            {
                Set(ref sensors, value);
            }
        }

        private Sensor selectedSensor;
        public Sensor SelectedSensor
        {
            get
            {
                return selectedSensor;
            }
            set
            {
                Set(ref selectedSensor, value);
            }
        }

        private string sensorsLocation;
        public string SensorsLocation
        {
            get { return sensorsLocation; }
            set { Set(ref sensorsLocation, value); }
        }
        #endregion properties

        #region private methods
        private void SearchFilter(string searchCriteria)
        {
            if (string.IsNullOrWhiteSpace(searchCriteria))
            {
                Sensors = oldClients;
                return;
            }

            searchCriteria = searchCriteria.Trim();
            var sensors = new List<Sensor>();

            foreach (var client in oldClients)
            {
                if (client.FullName.Contains(searchCriteria, StringComparison.InvariantCultureIgnoreCase))
                {
                    sensors.Add(client);
                }
            }

            Sensors = new ObservableCollection<Sensor>(sensors);
        }

        private async void GetSensorsLocation(Sensor sensor)
        {
            try
            {
                var sensorPresence = await serverHubProxy.Invoke<SensorPresence>("GetSensorPresence", sensor);
                var room = await serverHubProxy.Invoke<Room>("GetRoom", sensorPresence.RoomId);

                SensorsLocation = $"{sensor.FullName} was in {room.Name} at {sensorPresence.TimeStamp}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchboxLostFocusHandler(UIElement searchBox)
        {
            if (searchBox is TextBox)
            {
                if (((TextBox)searchBox).Text == "")
                {
                    ((TextBox)searchBox).Text = "Search for clients...";
                }
            }
        }

        private void SearchboxGotFocusHandler(UIElement searchBox)
        {
            if (searchBox is TextBox)
            {
                ((TextBox)searchBox).Text = "";
            }
        }
        #endregion methods

        #region public methods
        public async void SetupHubConnection()
        {
            var hubConnection = new HubConnection("http://localhost:8081");
            serverHubProxy = hubConnection.CreateHubProxy(Constants.HUBNAME);
            try
            {
                await hubConnection.Start();

                Sensors = new ObservableCollection<Sensor>(serverHubProxy.Invoke<IEnumerable<Sensor>>("GetAllRegisteredClients").Result);
                oldClients = sensors;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            hubConnection.Error += ex => Console.WriteLine("SignalR error: {0}", ex.Message);
        }
        #endregion public methods

        #region commands
        public RelayCommand<UIElement> SearchBoxGotFocusCommand { get; private set; }
        public RelayCommand<UIElement> SearchBoxLostFocusCommand { get; private set; }
        public RelayCommand<Sensor> GetClientsLocationCommand { get; private set; }
        public RelayCommand<string> SearchCommand { get; private set; }
        #endregion commands
    }
}