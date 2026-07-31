using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Application.Features.Dto
{
    public class GetReservationDto
    { 
        //Reservation
        public Guid? CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected, Cancelled, Completed
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Vehicle
        public Guid VehicleId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public decimal DailyRate { get; set; }  

        //Users
        // public Guid UserId { get; set; } 
        public string Email { get; set; } = string.Empty; 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }

        //Category
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;  // Motorcycle, Sedan, SUV, Van
        public string? Description { get; set; }
    }
}