using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class StartLocation
    {

        [Key]
        public int StartLocationId { get; set; }

        public DateTime Timestamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }



        [StringLength(450)]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        [NotMapped]
        public ApplicationUser ApplicationUser { get; set; }



    }
}
