 
namespace RMS.Domain.Entities;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Brand { get; set; } = string.Empty;      // Honda, Yamaha, Toyota
    public string Model { get; set; } = string.Empty;      // Civic, Mio, Vios
    public int Year { get; set; }                          // 2024
    public string PlateNumber { get; set; } = string.Empty; // ABC-1234
    public decimal DailyRate { get; set; }                 // 1500.00
    public string Status { get; set; } = "Available";      // Available, Rented, Maintenance, Archived
    public int CategoryId { get; set; }
    public VehicleCategory Category { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }               // Soft delete
}