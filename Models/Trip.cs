using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Trip
    {
        [Key]
        public string Id { get; set; }


        [Required]
        public string IdentityUserId { get; set; }

        [ForeignKey("IdentityUserId")]
        public IdentityUser IdentityUser { get; set; }

        



        [Required]
        public string VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }


        public Location StartLocation { get; set; }

        public Location EndLocation { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime EndedAt { get; set; }
     
    }

}
