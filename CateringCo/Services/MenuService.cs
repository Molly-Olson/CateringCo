using CateringCo.DTOs;
using CateringCo.Models;
using CateringCo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CateringCo.Services
{
    public class MenuService : IMenuService
    {
        private readonly CateringCoContext _context;
            public MenuService(CateringCoContext context)
            {
                 _context = context;
            }
        public async Task<List<MenuListItemDto>> GetAllAsync()
        {
            return await _context.MenuItems
                .AsNoTracking()
                .Where(m => m.Name != null && m.Name.Trim() != "" && m.Price >= 0)
                .OrderBy(m => m.Name)
                .Select(m => new MenuListItemDto
                {
                    Id = m.Id,
                    Name = m.Name!,
                    Description = m.Description,
                    Price = m.Price
                })
                .ToListAsync();
        }
        public async Task<MenuListItemDto?> GetByIdAsync(int id)
        {
            return await _context.MenuItems
                .AsNoTracking()
                .Where(m => m.Id == id)
                .Select(m => new MenuListItemDto
                {
                    Id = m.Id,
                    Name = m.Name!,
                    Description = m.Description,
                    Price = m.Price
                })
                .FirstOrDefaultAsync();
        }
    }
}
