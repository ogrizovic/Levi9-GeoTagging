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

        // Method that is going to broadcast positions of sensors to every sensor. Subscription not implemented yet.
        public void broadcastPositions(string sensor, string room, DateTime timeStamp)
        {
            Clients.All.showPositions(sensor, room, timeStamp);
        }

        public Task<IEnumerable<RoomPresence>> getAllPositions()
        {
            
        }
    }
}
