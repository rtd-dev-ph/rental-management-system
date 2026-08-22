namespace RMS.Domain.Entities;

public class VehicleImage
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public bool IsCover { get; set; }
    public int SortOrder { get; set; }
    public DateTime CreatedAt { get; set; } 
}
