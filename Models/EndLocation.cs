using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class EndLocation
    {


        [Key]
        public int EndLocationId { get; set; }


        public DateTime Timestamp { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }



        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }



        //[ForeignKey("Trip")]
        //public int TripId { get; set; }
        //public Trip Trip { get; set; }


    }
}
