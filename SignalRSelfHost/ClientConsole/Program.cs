using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public async void StartHub()
        {
            var connection = new HubConnection("http://localhost:8080");
            IHubProxy ServerHub = connection.CreateHubProxy("ServerHub");



        }

        public void showPositions(string sensor, string room, DateTime timeStamp)
        {
            // TODO: Implement the method for showing received info
        }
    }
}
