# Sprint 7: Vehicle Image Upload

**Date**: August 5-6, 2026  
**Status**: ✅ Complete

## Goal
Upload and manage vehicle images with cover photo support.

## API Endpoints

| Method | Endpoint | Description | Status |
|--------|----------|-------------|--------|
| POST | /api/vehicles/{id}/images | Upload image | ✅ |
| GET | /api/vehicles/{id}/images | Get vehicle images | ✅ |
| DELETE | /api/vehicles/images/{imageId} | Delete image | ✅ |

## What We Built
- ✅ VehicleImage entity with file metadata
- ✅ File upload with type/size validation
- ✅ Cover photo management (auto-unset old cover)
- ✅ Static file serving via wwwroot
- ✅ File deletion from disk + database

## Tech Used
- IFormFile for upload
- IHostEnvironment for path resolution
- Static files middleware

## Next Sprint
**Sprint 8: Testing & Polish**
