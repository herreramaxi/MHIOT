using System;

namespace MHIOT.Models
{
    public class TemperatureData
    {
        public int Id { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public DateTime? Date { get; set; }   
    }
}