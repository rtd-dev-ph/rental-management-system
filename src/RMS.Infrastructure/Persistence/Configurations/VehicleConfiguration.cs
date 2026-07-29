using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Domain.Entities;

namespace RMS.Infrastructure.Persistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicles");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Brand)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Model)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.PlateNumber)
            .IsRequired()
            .HasMaxLength(20);
        
        builder.Property(x => x.DailyRate)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
        
        builder.HasIndex(x => x.PlateNumber)
            .IsUnique()
            .HasFilter("\"DeletedAt\" IS NULL");
        
        builder.HasOne(x => x.Category)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.CategoryId);
        
        builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}
