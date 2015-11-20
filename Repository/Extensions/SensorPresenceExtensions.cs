using Repository.Data;
using Repository.DTOs;

namespace Repository.Extensions
{
    public static class SensorPresenceExtensions
    {
        public static PresenceDto Convert(this SensorPresence presence)
        {
            return new PresenceDto
            {
                RoomId = presence.roomId,
                SensorId = presence.sensorId,
                TimeStamp = presence.timeSample
            };
        }

        public static SensorPresence Convert(this PresenceDto presence)
        {
            return new SensorPresence
            {
                roomId = presence.RoomId,
                sensorId = presence.SensorId,
                timeSample = presence.TimeStamp
            };
        }
    }
}
