using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using RealTimeUber.Models;

namespace RealTimeUber.Models
{
    public class ApplicationUser : IdentityUser
    {
        public override string Id { get; set; }

        
        //public string Name { get; set; }
        //public string Email { get; set; }
        public string FirstName { get; internal set; }
        public string MobileNumber { get; internal set; }
        public string LastName { get; internal set; }
    }


}
