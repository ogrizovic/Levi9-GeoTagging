using Repository.Data;
using Repository.DTOs;
using Repository.Extensions;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class SensorPresenceRepository : ISensorPresenceRepository
    {
        public void CreateSensorPresence(SensorPresence presence, Sensor sensor)
        {
            using (var context = new ClientSensorLocationEntities())
            {
                //Check if sensor doesn't exist
                if (context.Sensors.Find(sensor.sensorId) == null)
                {
                    context.Sensors.Add(sensor);
                }

                // Check if sensor is present elsewhere
                if (context.SensorPresences.Find(sensor.sensorId) != null)
                {
                    context.SensorPresences.Remove(context.SensorPresences.Find(sensor.sensorId));
                }

                context.SensorPresences.Add(presence);
                context.SaveChanges();
            }
        }

        public PresenceDto GetSensorPresence(int sensorId)
        {
            using (var context= new ClientSensorLocationEntities())
            {
                return context.SensorPresences.Find(sensorId).Convert();
            }
        }
    }
}