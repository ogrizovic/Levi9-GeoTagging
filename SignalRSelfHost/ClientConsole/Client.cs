using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRSelfHost;
using Microsoft.AspNet.SignalR.Client;

namespace ClientConsole
{
    class Client
    {
        public string sensorId { get; set; }
        public string roomId { get; set; }
        public DateTime timeStamp { get; set; }

        public RoomPresence roomPresence;

        public Client(string sensorId)
        {
            this.sensorId = sensorId;
            Console.WriteLine("This is sensor {0} ", sensorId);
        }

        // Helper method used for testing.
        public RoomPresence generateRoomPresence()
        {
            RoomPresence retVal = new RoomPresence();

            retVal.sensor = sensorId;
            retVal.room = DateTime.Now.Millisecond.ToString();
            retVal.timeStamp = DateTime.Now;

            roomPresence = retVal;

            return retVal;
        }

        public async void StartHub(RoomPresence testObject)
        {
            // Establishing connection, creating hub proxy and defining method that server can call.
            var hubConnection = new HubConnection("http://localhost:8080");
            IHubProxy serverHubProxy = hubConnection.CreateHubProxy("ServerHub");
            serverHubProxy.On<RoomPresence>("broadcast", roomPresence => Console.WriteLine("Sensor '{0}' is in the room '{1}' on time: {2}", roomPresence.sensor, roomPresence.room, roomPresence.timeStamp));
            await hubConnection.Start();

            hubConnection.Error += ex => Console.WriteLine("SignalR error: {0}", ex.Message);

            // Invoking method on server
            await serverHubProxy.Invoke("broadcastPositions", testObject);



        }

    }
}
