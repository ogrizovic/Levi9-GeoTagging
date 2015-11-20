using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Generic;
using Repository.Interfaces;
using Repository.Repositories;
using Utilities;
using Repository.DTOs;
using Repository.Extensions;

namespace SignalRSelfHost
{
    [HubName(Constants.HUBNAME)]
    public class ServerHub : Hub
    {
        private ISensorPresenceRepository presenceRepository = new SensorPresenceRepository();
        private ISensorRepository sensorRepository = new SensorRepository();
        private IRoomRepository roomRepository = new RoomRepository();

        public void RecordLocation(PresenceDto presence, SensorDto sensor)
        {
            presenceRepository.CreateSensorPresence(presence.Convert(), sensor.Convert());
        }

        public IEnumerable<SensorDto> GetAllRegisteredClients()
        {
            return sensorRepository.GetAllRegisteredSensors();
        }

        public PresenceDto GetSensorPresence(SensorDto client)
        {
            return presenceRepository.GetSensorPresence(client.SensorId);
        }

        public RoomDto GetRoom(int roomId)
        {
            return roomRepository.GetRoom(roomId);
        }

        public IEnumerable<RoomDto> GetRooms()
        {
            return roomRepository.GetRooms();
        }
    }
}