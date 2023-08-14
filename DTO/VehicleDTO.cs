using RealTimeUber.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.DTO
{
    public class VehicleDTO
    {
        //public int Id { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        [Required]
        public string DriverId { get; set; }

    }
}
