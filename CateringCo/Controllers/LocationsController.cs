using CateringCo.Models;
using Microsoft.AspNetCore.Mvc;
using CateringCo.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
            var vm = new LocationsListViewModel
            {
                Locations = locations,
                TotalCount = locations.Count,
                SearchTerm = "Our Locations",
                EmptyMessage = "No locations found."

            };

            return View(vm);
        }
        public IActionResult Create()
        {
            return View();
        }

        // Week six
        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            return View();
        }

    }
}

//not sure what this is down here...
        //[Route("Locations/Info")]
        //public IActionResult About()
        //{
        //    return View();
        //}
        //public IActionResult Details()
        //{
        //    return View();
        //}
    

