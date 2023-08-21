using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealTimeUber.Models
{
    public class Requestt
    {
        [Key]
        public int Id { get; set; }



        [ForeignKey("Passenger")]
        public string PassengerId { get; set; }  // FK

        [ForeignKey("StartLocation")]
        public int StartLocationId { get; set; }

        [ForeignKey("EndLocation")]
        public int EndLocationId { get; set; }




        public Passenger Passenger { get; set; }
        public StartLocation StartLocation { get; set; }
        public EndLocation EndLocation { get; set; }

    }



}
