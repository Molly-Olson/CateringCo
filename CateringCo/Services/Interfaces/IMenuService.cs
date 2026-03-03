using CateringCo.DTOs;

namespace CateringCo.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuListItemDto>> GetAllAsync();
        Task<MenuListItemDto?> GetByIdAsync(int id);
    }
}
