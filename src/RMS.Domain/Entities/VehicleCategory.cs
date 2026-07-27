 
namespace RMS.Domain.Entities;

public class VehicleCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;  // Motorcycle, Sedan, SUV, Van
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}