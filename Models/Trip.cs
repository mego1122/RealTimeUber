using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }

        [ForeignKey("Request")]
        public int RequestId { get; set; }
        public Requestt Request { get; set; }


        [StringLength(450)]
        [ForeignKey("Driver")]
        public string DriverId { get; set; }
        public Driver Driver { get; set; }


        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}