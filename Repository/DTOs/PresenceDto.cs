using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTOs
{
    public class PresenceDto
    {
        public int SensorId { get; set; }
        public int RoomId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
