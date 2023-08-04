using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Notification
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public IdentityUser IdentityUser { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
        
    }

}
