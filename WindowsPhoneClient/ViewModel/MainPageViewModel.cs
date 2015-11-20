using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UtilitiesPortable.SharedCommands;
using UtilitiesPortable.SharedModels;
using Windows.Data.Json;
using Windows.UI.Popups;
using WindowsPhoneClient.ViewModel;

namespace WindowsPhoneClient
{
    public class MainPageViewModel : ViewModelBaseWinPhone
    {
        private List<Sensor> oldSensors;

        public MainPageViewModel()
        {
            GetSensorData();
            GetSensorLocationCommand = new RelayCommand<Sensor>(GetSensorLocation);
            CheckInCommand = new RelayCommand(NavToCheckIn);
        }

        private void NavToCheckIn()
        {
            navigationService.NavigateTo("checkIn");
        }

        private void GetSensorData()
        {
            var result = serverHubProxy.Invoke<List<object>>("GetAllRegisteredClients").Result;
            var clientSensors = new List<Sensor>();

            foreach (var item in result)
            {
                JsonObject sensor = JsonObject.Parse(item.ToString());
                clientSensors.Add(new Sensor
                {
                    FirstName = sensor["FirstName"].GetString(),
                    LastName = sensor["LastName"].GetString(),
                    SensorId = (int)sensor["SensorId"].GetNumber(),
                    SensorMac = sensor["SensorMac"].GetString(),
                    FullName = sensor["FirstName"].GetString() + " " + sensor["LastName"].GetString()
                });
            }

            Sensors = new ObservableCollection<Sensor>(clientSensors);
            //oldSensors = new List<Sensor>(sensors);
        }

        private void GetSensorLocation(Sensor sensor)
        {
            if (sensor == null)
            {
                MessageDialog msgBox = new MessageDialog("You must choose a sensor", "Error");
                msgBox.ShowAsync();
                return;
            }
            var result = serverHubProxy.Invoke<SensorPresence>("GetSensorPresence", sensor).Result;
            var room = serverHubProxy.Invoke<Room>("GetRoom", result.RoomId).Result;

            SensorLocation = string.Format($"{SelectedSensor.FullName} was in {room.Name} at {result.TimeStamp}");
        }

        private ObservableCollection<Sensor> sensors = new ObservableCollection<Sensor>();
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

        private string sensorLocation;
        public string SensorLocation
        {
            get
            {
                return sensorLocation;
            }
            set
            {
                Set(ref sensorLocation, value);
            }
        }

        public RelayCommand<Sensor> GetSensorLocationCommand { get; private set; }
        public RelayCommand CheckInCommand { get; private set; }

        #region commented-out

        //private void SearchFilter(string searchCriteria)
        //{
        //    if (string.IsNullOrWhiteSpace(searchCriteria))
        //    {
        //        Sensors = new ObservableCollection<Sensor>(oldSensors);
        //        return;
        //    }

        //    searchCriteria = searchCriteria.Trim();
        //    var sensors = new List<Sensor>();

        //    foreach (var client in oldSensors)
        //    {
        //        if (client.FullName.Contains(searchCriteria, StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            sensors.Add(client);
        //        }
        //    }

        //    Sensors = new ObservableCollection<Sensor>(sensors);
        //}
        #endregion
    }
}
