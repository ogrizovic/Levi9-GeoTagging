using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WindowsPhoneClient.Models;

namespace WindowsPhoneClient.ViewModel
{
    public class CheckInPageViewModel : ViewModelBase
    {
        public CheckInPageViewModel()
        {
            CheckInCommand = new RelayCommand<int>(CheckIn);
            FirstName = "Zoran";
            LastName = "Lisovac";
            Rooms = GetRooms();
        }

        private ObservableCollection<Room> GetRooms()
        {
            var result = serverHubProxy.Invoke<List<Room>>("GetRooms").Result;

            return new ObservableCollection<Room>(result);
        }

        private async void CheckIn(int roomId)
        {
            var sensor = new Sensor
            {
                FirstName = "Zoran",
                LastName = "Lisovac",
                SensorId = 5,
                SensorMac = "mac5"
            };

            var presence = new SensorPresence
            {
                RoomId = roomId,
                SensorId = sensor.SensorId,
                TimeStamp = DateTime.Now
            };

            await serverHubProxy.Invoke("RecordLocation", presence, sensor);
            navigationService.NavigateTo("checkedInList");
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                Set(ref firstName, value);
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                Set(ref lastName, value);
            }
        }

        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        public ObservableCollection<Room> Rooms
        {
            get { return rooms; }
            set
            {
                Set(ref rooms, value);
            }
        }

        private Room selectedRoom;
        public Room SelectedRoom
        {
            get { return selectedRoom; }
            set { Set(ref selectedRoom, value); }
        }

        public RelayCommand<int> CheckInCommand { get; private set; }
    }
}
