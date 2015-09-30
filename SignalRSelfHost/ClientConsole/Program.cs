using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using SignalRSelfHost;

namespace ClientConsole
{
    class Program
    {
        //public static RoomPresence testObject;

        static void Main(string[] args)
        {
            Client testClient1 = new Client("testSenzor1");
            testClient1.roomPresence = testClient1.generateRoomPresence();
            testClient1.StartHub(testClient1.roomPresence);

            Client testClient2 = new Client("testSenzor2");
            testClient2.roomPresence = testClient2.generateRoomPresence();
            testClient2.StartHub(testClient2.roomPresence);

            
            Console.WriteLine("console app");
            Console.ReadLine();
            
        }

        //public static async void StartHub()
        //{
        //    // Establishing connection, creating hub proxy and defining method that server can call.
        //    var hubConnection = new HubConnection("http://localhost:8080");
        //    IHubProxy serverHubProxy = hubConnection.CreateHubProxy("ServerHub");
        //    serverHubProxy.On<RoomPresence>("broadcast", roomPresence => Console.WriteLine("Sensor '{0}' is in the room '{1}' on time: {2}", roomPresence.sensor, roomPresence.room, roomPresence.timeStamp));
        //    await hubConnection.Start();
            
        //    hubConnection.Error += ex => Console.WriteLine("SignalR error: {0}", ex.Message);

        //    // Invoking method on server
        //    await serverHubProxy.Invoke("broadcastPositions", testObject);

        //}

        //public void broadcast(RoomPresence rp)
        //{
        //    // TODO: Implement the method for showing received info
        //    Console.Write(rp.sensor, rp.room, rp.timeStamp);
        //}
    }
}
