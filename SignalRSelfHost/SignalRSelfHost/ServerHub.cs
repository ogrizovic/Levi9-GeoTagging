using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRSelfHost
{
    [HubName("ServerHub")]
    public class ServerHub : Hub
    {

        // Method that is invoked from client
        public void broadcastPositions(RoomPresence roomPresence)
        {
            // Calling client method
            Clients.All.broadcast(roomPresence);
        }

        //public Task<IEnumerable<RoomPresence>> getAllPositions()
        //{
            
        //}
    }
}
