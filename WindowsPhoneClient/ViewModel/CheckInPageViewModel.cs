using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UtilitiesPortable.SharedModels;
using Windows.ApplicationModel.Contacts;
using Windows.System.UserProfile;
using Windows.UI.Popups;

namespace WindowsPhoneClient.ViewModel
{
    public class CheckInPageViewModel : ViewModelBaseWinPhone
    {
        public CheckInPageViewModel()
        {
            CheckInCommand = new RelayCommand<int>(CheckIn);
            BackCommand = new RelayCommand(NavBack);
            //GetUsersName();
            Rooms = GetRooms();
        }

        private void NavBack()
        {
            navigationService.NavigateTo("checkedInList");
        }

        private async void GetUsersName()
        {
            // TODO: Find the way to get the currently logged user's first and last name
            FirstName = await UserInformation.GetFirstNameAsync();
            LastName = await UserInformation.GetLastNameAsync();
        }

        private ObservableCollection<Room> GetRooms()
        {
            var result = serverHubProxy.Invoke<List<Room>>("GetRooms").Result;

            return new ObservableCollection<Room>(result);
        }

        private async void CheckIn(int roomId)
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || SelectedRoom == null)
            {
                MessageDialog dialog = new MessageDialog("You must enter first and last name and select a room", "Error");
                await dialog.ShowAsync();
                return;
            }

            var sensor = new Sensor
            {
                FirstName = FirstName,
                LastName = LastName,
                SensorId = 5,
                SensorMac = "1"
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

        private string firstName = string.Empty;
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

        private string lastName = string.Empty;
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
        public RelayCommand BackCommand { get; private set; }
    }
}