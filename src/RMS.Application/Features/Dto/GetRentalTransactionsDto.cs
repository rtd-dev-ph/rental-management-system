using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Application.Features.Dto
{
    public class GetRentalTransactionsDto
    {
        public Guid RentalId { get; set; }
        public Guid ReservationId { get; set; } 
        public Guid VehicleId { get; set; } 
        public DateTime PickupDate { get; set; }     
        public DateTime? ReturnDate { get; set; }  
        public string? RentalStatus { get; set; } 
        public string? RentalNotes { get; set; } 
  
        public string ReservationStatus { get; set; } = "Pending"; // Pending, Approved, Rejected, Cancelled, Completed 
        public string? ReservationNotes { get; set; } 

        public string Brand { get; set; } = string.Empty;      // Honda, Yamaha, Toyota
        public string Model { get; set; } = string.Empty;      // Civic, Mio, Vios
        public int Year { get; set; }                          // 2024
        public string PlateNumber { get; set; } = string.Empty;
    }
}