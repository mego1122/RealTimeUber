using System.ComponentModel.DataAnnotations;

namespace RealTimeUber.Models
{
    public class Vehicle
    {
        [Key]
        public string Id { get; set; }

        public string LicensePlate { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
    }

}
