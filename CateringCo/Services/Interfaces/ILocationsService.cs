using CateringCo.DTOs;

namespace CateringCo.Services.Interfaces
{

    public interface ILocationsService
    {
        Task<List<LocationListItemDto>> GetAllAsync();
        Task<LocationListItemDto?> GetByIdAsync(int id);
    }
}
