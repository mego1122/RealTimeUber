using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }

        [ForeignKey("Trip")]
        public int TripId { get; set; } // FK 
        [NotMapped]
        public Trip Trip { get; set; }
    }

}
