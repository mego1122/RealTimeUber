using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealTimeUber.Models
{
    public class Request
    {

        [Key]
        public string Id { get; set; }
        [Required]
        public string DriverId { get; set; }

        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }

        [Required]
        public string PassengerId { get; set; }

        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }
        public Location PickupLocation { get; set; }
      
    }

}
