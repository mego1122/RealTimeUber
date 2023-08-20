using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Passenger : ApplicationUser
    {
        public Passenger()
        {
            Trips = new HashSet<Trip>();
            Requests = new HashSet<Requestt>();
        }

        [NotMapped]
        public ICollection<Trip> Trips { get; set; }
        [NotMapped]
        public ICollection<Requestt> Requests { get; set; }


    }
}
