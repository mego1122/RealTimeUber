using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Passenger : ApplicationUser
    {
        public Passenger()
        {
            Trips = new HashSet<Trip>();
            Requests = new HashSet<Request>();
        }

        [NotMapped]
        public ICollection<Trip> Trips { get; set; }
        [NotMapped]
        public ICollection<Request> Requests { get; set; }


    }
}
