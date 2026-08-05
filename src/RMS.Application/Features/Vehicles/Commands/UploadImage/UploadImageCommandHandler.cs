// UploadImageCommandHandler.cs
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RMS.Application.Common.Interfaces;
using RMS.Application.Common.Models;
using RMS.Domain.Entities;

namespace RMS.Application.Features.Vehicles.Commands.UploadImage;

public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Response<Guid>>
{
    private readonly IApplicationDbContext _context;
    private readonly IHostEnvironment _env;

    public UploadImageCommandHandler(IApplicationDbContext context, IHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public async Task<Response<Guid>> Handle(UploadImageCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _context.Vehicles
            .FirstOrDefaultAsync(v => v.Id == request.VehicleId, cancellationToken);

        if (vehicle == null)
            return Response<Guid>.Failure("Vehicle not found");

        // Validate file
        var allowedTypes = new[] { "image/jpeg", "image/png", "image/webp" };
        if (!allowedTypes.Contains(request.File.ContentType))
            return Response<Guid>.Failure("Only JPEG, PNG, and WebP images are allowed");

        if (request.File.Length > 5 * 1024 * 1024)
            return Response<Guid>.Failure("File size must be less than 5MB");

        // Save file
        var uploadsFolder = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads");
        Directory.CreateDirectory(uploadsFolder);

        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.File.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.File.CopyToAsync(stream, cancellationToken);
        }

        // If setting as cover, remove existing cover
        if (request.IsCover)
        {
            var existingCovers = await _context.VehicleImages
                .Where(i => i.VehicleId == request.VehicleId && i.IsCover)
                .ToListAsync(cancellationToken);

            foreach (var cover in existingCovers)
                cover.IsCover = false;
        }

        // Save to database
        var image = new VehicleImage
        {
            Id = Guid.NewGuid(),
            VehicleId = request.VehicleId,
            FileName = request.File.FileName,
            FilePath = $"/uploads/{fileName}",
            FileSize = request.File.Length,
            IsCover = request.IsCover,
            SortOrder = 0,
            CreatedAt = DateTime.UtcNow
        };

        _context.VehicleImages.Add(image);
        await _context.SaveChangesAsync(cancellationToken);

        return Response<Guid>.Success(image.Id);
    }
}