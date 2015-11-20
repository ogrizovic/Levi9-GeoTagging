using Repository.DTOs;
using Repository.Interfaces;
using System.Collections.Generic;
using Repository.Extensions;
using Repository.Data;

namespace Repository.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        public IEnumerable<SensorDto> GetAllRegisteredSensors()
        {
            using (var context  = new ClientSensorLocationEntities())
            {
                foreach (var sensor in context.Sensors)
                {
                    yield return sensor.Convert();
                }
            }
        }

        public SensorDto GetSensor(int sensorId)
        {
            using (var context = new ClientSensorLocationEntities())
            {
                return context.Sensors.Find(sensorId).Convert();
            }
        }
    }
}