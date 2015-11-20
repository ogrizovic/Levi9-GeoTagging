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
            var context = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
            // Calling client method
            context.Clients.All.broadcast(roomPresence);
        }
    }
}
