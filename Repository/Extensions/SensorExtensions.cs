using Repository.Data;
using Repository.DTOs;

namespace Repository.Extensions
{
    public static class SensorExtensions
    {
        public static SensorDto Convert(this Sensor sensor)
        {
            return new SensorDto
            {
                FirstName = sensor.firstName,
                LastName = sensor.lastName,
                SensorId = sensor.sensorId,
                SensorMac = sensor.sensorMac
            };
        }

        public static Sensor Convert(this SensorDto sensor)
        {
            return new Sensor
            {
                firstName = sensor.FirstName,
                lastName = sensor.LastName,
                sensorId = sensor.SensorId,
                sensorMac = sensor.SensorMac
            };
        }
    }
}