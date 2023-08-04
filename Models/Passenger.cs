using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Passenger : IdentityUser
    {
        

        public List<Request> Requests { get; set; }

        
      //  public List<Trip> Trips { get; set; }

        
        //public List<Rating> Ratings { get; set; }
    }

}
