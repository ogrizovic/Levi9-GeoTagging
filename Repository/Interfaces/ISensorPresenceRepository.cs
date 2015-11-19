using Repository.Data;
using Repository.DTOs;

namespace Repository.Interfaces
{
    public interface ISensorPresenceRepository
    {
        void CreateSensorPresence(SensorPresence presence, Sensor sensor);

        //void UpdateSensorPresence(SensorPresence presence);

        //void DeleteSensorPresence(SensorPresence presence);

        PresenceDto GetSensorPresence(int sensorId);
    }
}