using CateringCo.Models;
using Microsoft.AspNetCore.Mvc;
using CateringCo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using CateringCo.Services.Interfaces;

namespace CateringCo.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationsService _locationsService;
        public LocationsController(ILocationsService locationsService)
        {
            _locationsService = locationsService;
        }
        public async Task<IActionResult> Index()
        {
            var locations = await _locationsService.GetAllAsync();
            var vm = new LocationsListViewModel
            {
                Locations = locations,
                PageTitle = "Our Locations",
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
        //week eight
        [Route ("Locations/Info")]
        public IActionResult About()
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
    

