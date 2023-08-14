using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealTimeUber.DTO
{
    public class StartLocationDTO
    {
        public DateTime Timestamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }


        public string ApplicationUserId { get; set; }
    }
}
