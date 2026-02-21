using CateringCo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CateringCo.Controllers
{
    public class LocationsController : Controller
    {
        private readonly CateringCoContext _context;
        public LocationsController(CateringCoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var locations = _context.Locations.ToList();
            return View(locations);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}


        //[Route("Locations/Info")]
        //public IActionResult About()
        //{
        //    return View();
        //}
        //public IActionResult Details()
        //{
        //    return View();
        //}
    

