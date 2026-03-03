using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CateringCo.Services.Interfaces;


namespace CateringCo.Controllers
{
    [ApiController]
    [Route("api/Locations")]

    public class LocationsApiController : ControllerBase
    {
        private readonly ILocationsService _locationsService;
        public LocationsApiController(ILocationsService locationsService)
        {
            _locationsService = locationsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _locationsService.GetAllAsync();
                //.AsNoTracking()
                //.Select(l => new { l.Id, l.Name })
                //.ToListAsync();
            return Ok(locations);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var locations = await _locationsService.GetByIdAsync(id);
                //.AsNoTracking()
                //.Where(l => l.Id == id)
                //.Select(l => new { l.Id, l.Name })
                //.FirstOrDefaultAsync();

            if (locations == null)
            {
                return NotFound();
            }

            return Ok(locations);
                }
    }
}
