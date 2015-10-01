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
        static void Main(string[] args)
        {

            // Making test clients and generating their room presence to try out the broadcasting.
            Client testClient1 = new Client("testSenzor1");
            testClient1.roomPresence = testClient1.generateRoomPresence();
            Client testClient2 = new Client("testSenzor2");
            testClient2.roomPresence = testClient2.generateRoomPresence();
            Client testClient3 = new Client("testSenzor3");
            testClient3.roomPresence = testClient3.generateRoomPresence();


            testClient1.StartHub(testClient1.roomPresence, true); 
            testClient2.StartHub(testClient2.roomPresence, false);
            testClient3.StartHub(testClient3.roomPresence, false);

            Console.ReadLine();

            
        }
    }
}
