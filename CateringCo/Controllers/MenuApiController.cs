using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace CateringCo.Controllers
{
    [ApiController]
    [Route("api/Menu")]

    public class MenuApiController : ControllerBase
    {
        private readonly CateringCoContext _context;
        public MenuApiController(CateringCoContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menuItems = await _context.MenuItems
                .AsNoTracking()
                .Select(l => new { l.Id, l.Name })
                .ToListAsync();
            return Ok(menuItems);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menuItems = await _context.MenuItems
                .AsNoTracking()
                .Where(l => l.Id == id)
                .Select(l => new { l.Id, l.Name })
                .FirstOrDefaultAsync();

            if (menuItems == null)
            {
                return NotFound();
            }

            return Ok(menuItems);
        }
    }
}
