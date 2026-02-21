using CateringCo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CateringCo.Controllers
{
    public class MenuController : Controller
    {
        private readonly CateringCoContext _context;
        public MenuController(CateringCoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
                var menuItems = _context.MenuItems.ToList();
                return View(menuItems);
        }
        public IActionResult Create()
        {
            return View();
        }

        [Route("Menu/Info")]
        
        public IActionResult Details()
        {
            return View();
        }
    }
}
