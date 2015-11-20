using Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISensorRepository
    {
        //void AddSensor(Sensor sensor);

        //void UpdateSensor(Sensor sensor);

        //void DeleteSensor(int sensorId);

        SensorDto GetSensor(int sensorId);

        IEnumerable<SensorDto> GetAllRegisteredSensors();
    }
}