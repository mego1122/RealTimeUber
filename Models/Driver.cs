using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Driver : IdentityUser
    {

        public string VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        public bool IsAvailable { get; set; }
       // public List<Trip> Trips { get; internal set; }
      //  public List<Rating> Ratings { get; internal set; }
    }

}
