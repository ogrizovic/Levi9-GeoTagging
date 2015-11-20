using Repository.Data;
using Repository.DTOs;
using Repository.Extensions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Repository.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public void AddRoom(Room room)
        {
            // TODO
            throw new NotImplementedException();
        }

        public RoomDto GetRoom(int roomId)
        {
            using (var context = new ClientSensorLocationEntities())
            {
                return context.Rooms.Find(roomId).Convert();
            }
        }

        public IEnumerable<RoomDto> GetRooms()
        {
            var result = new List<RoomDto>();
            using (var context = new ClientSensorLocationEntities())
            {
                foreach (var room in context.Rooms)
                {
                    result.Add(room.Convert());
                }
            }

            return result;
        }

        public void UpdateRoom(Room room)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}