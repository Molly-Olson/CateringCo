using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace CateringCo.Controllers
{
    [ApiController]
    [Route("api/Locations")]

    public class LocationsApiController : ControllerBase
    {
        private readonly CateringCoContext _context;
        public LocationsApiController(CateringCoContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _context.Locations
                .AsNoTracking()
                .Select(l => new { l.Id, l.Name })
                .ToListAsync();
            return Ok(locations);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var locations = await _context.Locations
                .AsNoTracking()
                .Where(l => l.Id == id)
                .Select(l => new { l.Id, l.Name })
                .FirstOrDefaultAsync();

            if (locations == null)
            {
                return NotFound();
            }

            return Ok(locations);
                }
    }
}
