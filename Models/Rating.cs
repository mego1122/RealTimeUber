using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Rating
    {
        [Key]
        public string Id { get; set; }


        [Required]
        public string IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser IdentityUser { get; set; }


        public int Stars { get; set; }

        public string Comments { get; set; }

  

     
    }

}
