using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Domain.Entities;

namespace RMS.Infrastructure.Persistence.Configurations;
  public class RoleConfiguration : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder.ToTable("roles");

      builder.HasKey(x => x.Id);

      builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(50);

      builder.Property(x => x.Description)
      .HasMaxLength(200);

      builder.HasIndex(x => x.Name)
      .IsUnique();
    }
  }
