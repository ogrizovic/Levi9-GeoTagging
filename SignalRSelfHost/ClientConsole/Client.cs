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
        private IHubProxy serverHubProxy;

        public Client(string sensorId)
        {
            this.sensorId = sensorId;
            Console.WriteLine("Sensor {0} created ", sensorId);

            
        }

        // Helper method used for testing.
        public RoomPresence generateRoomPresence()
        {
            RoomPresence retVal = new RoomPresence();

            retVal.sensor = sensorId;
            retVal.room = DateTime.Now.Millisecond.ToString();
            retVal.timeStamp = DateTime.Now;

            //roomPresence = retVal;

            return retVal;
        }

        // Establishing connection, creating hub proxy and defining method that server can call. If flag is true invoke the broadcast
        public async void StartHub(RoomPresence testObject, bool flag)
        {

            var hubConnection = new HubConnection("http://localhost:8080");
            IHubProxy serverHubProxy = hubConnection.CreateHubProxy("ServerHub");
            serverHubProxy.On<RoomPresence>("broadcast", roomPresence => Console.WriteLine("Sensor '{0}' is in the room '{1}' on time: {2}", roomPresence.sensor, roomPresence.room, roomPresence.timeStamp));
            await hubConnection.Start();

            hubConnection.Error += ex => Console.WriteLine("SignalR error: {0}", ex.Message);

            // Invoking method on server

            if (flag)
            { 
                await serverHubProxy.Invoke("broadcastPositions", testObject);
            }


        }

    }
}
