using System;

namespace WindowsPhoneClient.Models
{
    public class SensorPresence
    {
        public int SensorId { get; set; }
        public int RoomId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}