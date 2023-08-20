using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.DTO
{
    public class RequestDTO
    {
        public string PassengerId { get; set; } 
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
    }
}
