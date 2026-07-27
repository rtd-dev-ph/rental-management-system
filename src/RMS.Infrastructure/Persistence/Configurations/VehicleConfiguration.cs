using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Domain.Entities;

namespace TodoApp.Infrastructure.Persistence.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<Vehicle>
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

        builder.HasOne(x =>x.Category)
        .WithMany(x => x.Vehicles)
        .HasForeignKey(x => x.CategoryId); 

         builder.HasQueryFilter(x => x.DeletedAt == null);
    }
}