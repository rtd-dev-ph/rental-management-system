using Microsoft.EntityFrameworkCore;
using RMS.Domain.Entities;

namespace RMS.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<Vehicle> Vehicles { get; }
    DbSet<VehicleCategory> VehicleCategories { get; }
    DbSet<Reservation> Reservations { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
