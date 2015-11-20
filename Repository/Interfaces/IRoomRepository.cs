using Repository.Data;
using Repository.DTOs;
using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);

        void UpdateRoom(Room room);

        RoomDto GetRoom(int roomId);

        IEnumerable<RoomDto> GetRooms();
    }
}