using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CateringCo.Services.Interfaces;


namespace CateringCo.Controllers
{
    [ApiController]
    [Route("api/Menu")]

    public class MenuApiController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuApiController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menuItems = await _menuService.GetAllAsync();
                //.AsNoTracking()
                //.Select(l => new { l.Id, l.Name })
                //.ToListAsync();
            return Ok(menuItems);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menuItems = await _menuService.GetByIdAsync(id);
                //.AsNoTracking()
                //.Where(l => l.Id == id)
                //.Select(l => new { l.Id, l.Name })
                //.FirstOrDefaultAsync();

            if (menuItems == null)
            {
                return NotFound();
            }

            return Ok(menuItems);
        }
    }
}
