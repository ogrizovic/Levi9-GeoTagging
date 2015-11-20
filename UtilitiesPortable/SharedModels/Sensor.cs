namespace UtilitiesPortable.SharedModels
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string SensorMac { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

            set { }
        }
    }
}