using Repository.Data;
using Repository.DTOs;
using System.Collections.Generic;

namespace Repository.Extensions
{
    public static class RoomExtensions
    {
        public static RoomDto Convert(this Room room)
        {
            return new RoomDto
            {
                Level = room.level,
                Name = room.name,
                RoomId = room.roomId,
                Ssid = room.ssid,
                Ssidmac = room.ssidmac
            };
        }

        public static IEnumerable<RoomDto> Convert(this IEnumerable<Room> rooms)
        {
            foreach (var room in rooms)
            {
                yield return room.Convert();
            }
        }
    }
}