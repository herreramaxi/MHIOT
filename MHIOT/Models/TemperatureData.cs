using System;

namespace MHIOT.Models
{
    public class TemperatureData
    {
        public int Id { get; set; }
        public int? Temperature { get; set; }
        public int? Humidity { get; set; }
        public DateTime? Date { get; set; }   
    }
}