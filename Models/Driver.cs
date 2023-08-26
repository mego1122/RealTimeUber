using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace RealTimeUber.Models
{
    public class Driver : ApplicationUser
    {
        public Driver()
        {
            StartLocations = new HashSet<StartLocation>();
            EndLocations = new HashSet<EndLocation>();
        }

        [ForeignKey("Vehicle")]
        // [DefaultValue(0)]
        public int VehicleId { get; set; } // FK
        public Vehicle Vehicle { get; set; }
        [NotMapped]
        public ICollection<Trip> Trips { get; set; }


     
        public ICollection<StartLocation> StartLocations { get; set; }

       
        public ICollection<EndLocation> EndLocations { get; set; }
    }
}
