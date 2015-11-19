using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;

namespace TesterApp
{
    class Program
    {
        // Use this console app to make calls to SignalR server and debug the results if needed

        static void Main(string[] args)
        {
            IHubProxy serverHubProxy;
            var hubConnection = new HubConnection("http://localhost:8081");

            serverHubProxy = hubConnection.CreateHubProxy("ServerHub");
            hubConnection.Start().Wait();
            TestCall(serverHubProxy);

            Console.ReadLine();
        }

        private static async void TestCall(IHubProxy serverHubProxy)
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
                RoomId = 1,
                SensorId = sensor.SensorId,
                TimeStamp = DateTime.Now
            };

            //var result = await serverHubProxy.Invoke<List<Room>>("GetRooms");
            serverHubProxy.Invoke("RecordLocation", presence, sensor);
        }
    }

    internal class Sensor
    {
        public int SensorId { get; set; }
        public Sensor()
        {
        }
        public string SensorMac { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }

    internal class SensorPresence
    {
        public int SensorId { get; set; }
        public int RoomId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Ssid { get; set; }
        public string Ssidmac { get; set; }
    }
}
