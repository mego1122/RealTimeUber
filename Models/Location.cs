using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Location
    {
        [Key]
        public String Id { get; set; }

        [Required]
        public string IdentityUserID { get; set; }

        [ForeignKey("IdentityUserID")]
        public IdentityUser IdentityUser { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime RecordedAt { get; set; }
    }

}
