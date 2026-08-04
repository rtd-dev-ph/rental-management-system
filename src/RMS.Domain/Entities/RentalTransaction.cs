using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Domain.Entities
{
    public class RentalTransaction
    {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; } = null!;
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        public DateTime PickupDate { get; set; }       // When they got the vehicle
        public DateTime? ReturnDate { get; set; }      // Null until returned
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Active";  // Active, Completed
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}