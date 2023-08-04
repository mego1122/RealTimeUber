using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace RealTimeUber.Models
{
    public partial class IdentityUser
    {

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
        public List< Notification> Notifications { get; internal set; }

        // Other properties

        public List<Rating> Ratings { get; internal set; }
        public List<Trip> Trip { get; internal set; }
    }

}
