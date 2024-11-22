using System;
using System.ComponentModel.DataAnnotations;

namespace AircraftService.Models.Entities
{
    public class Aircraft
    {
        //public int Id { get; set; }

        [Key]
        [MaxLength(10)]
        public string Registration { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }


        [Required]
        [MaxLength(50)]
        public string CurrentStatus { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }
        public int TotalFlightHours { get; set; } 
        public int Cycles { get; set; } 

        //[Required]
        //public int FuelManagementDataId { get; set; }
        //public FuelManagementData FuelManagementData { get; set; }
    }
}
