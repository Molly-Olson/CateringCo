using CateringCo.DTOs;
using CateringCo.Models;
using CateringCo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringCo.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly CateringCoContext _context;
        public LocationsService(CateringCoContext context)
        {
            _context = context;
        }
        public async Task<List<LocationListItemDto>> GetAllAsync()
        {
            return await _context.Locations
                .AsNoTracking()
                .Where(l => 

                // These two lines came from AI
                //!string.IsNullOrWhiteSpace(l.Name) &&
                //!string.IsNullOrWhiteSpace(l.Address))

                l.Name != null && l.Name.Trim() != "" && l.Address != null && l.Address.Trim() != "")  //// I am not sure what goes here in place of the 0 for price now that it is an address string
                .OrderBy(l => l.Name)
                .Select(l => new LocationListItemDto
                {
                    Id = l.Id,
                    Name = l.Name!,
                    Address = l.Address,
                    Phone = l.Phone
                })
                .ToListAsync();
        }
        public async Task<LocationListItemDto?> GetByIdAsync(int id)
        {
            return await _context.Locations
                .AsNoTracking()
                .Where(l => l.Id == id)
                .Select(l => new LocationListItemDto
                {
                    Id = l.Id,
                    Name = l.Name!,
                    Address = l.Address,
                    Phone = l.Phone
                })
                .FirstOrDefaultAsync();
        }
    }
}