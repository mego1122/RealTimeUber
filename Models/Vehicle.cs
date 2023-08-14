using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Trips = new List<Trip>();
            Driver = new Driver();
        }


        [Key]
        public int Id { get; set; }
        public string LicensePlate { get; set; }

        [ForeignKey("Driver")]
        [StringLength(450)]
        public string DriverId { get; set; } // FK
        [NotMapped]
        public Driver Driver { get; set; }
        [NotMapped]

        public ICollection<Trip> Trips { get; set; }
    }
}


