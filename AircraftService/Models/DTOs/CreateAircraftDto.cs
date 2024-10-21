using System;
using System.ComponentModel.DataAnnotations;

namespace AircraftService.Models.DTOs
{
    // DTO for creating an Aircraft
    public class CreateAircraftDto
    {
        [Required]
        [StringLength(10, ErrorMessage = "Registration must be between 1 and 10 characters.")]
        public string Registration { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Aircraft type must be between 1 and 50 characters.")]
        public string Model { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Total flight hours must be a non-negative value.")]
        public int TotalFlightHours { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Fuel capacity must be a non-negative value.")]
        public int FuelCapacity { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Current fuel level must be a non-negative value.")]
        public int CurrentFuelLevel { get; set; }

        public string CurrentStatus { get; set; } = "Airworthy";

        public int Cycles { get; set; }

        public FuelManagementDataDto FuelManagementDataDto { get; set; } = new FuelManagementDataDto() 
        { 
            FuelCapacity = 100000, 
            FuelOnBoard = 30000, 
            LastRefueled = DateTime.Now, 
            PlannedUplift = 0, 
            RecentUplift = 0 
        };
    }
}
