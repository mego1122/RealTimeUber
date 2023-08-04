using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Payment
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string PassengerId { get; set; }
        [ForeignKey("PassengerId")]
        public Passenger Passenger { get; set; }

        public string Amount { get; set; }

        public string PaymentMethod { get; set; }
        [Required]
        public string TripId { get; set; }

        [ForeignKey("TripId")]
        public Trip Trip { get; set; }
    }

}
