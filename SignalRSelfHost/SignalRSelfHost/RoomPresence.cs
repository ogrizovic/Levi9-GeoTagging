using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRSelfHost
{
    public class RoomPresence
    {
        public string sensor { get; set; }
        public string room { get; set; }
        public DateTime timeStamp { get; set; }

    }
}
