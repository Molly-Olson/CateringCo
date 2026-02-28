using CateringCo.Models;
using Microsoft.AspNetCore.Mvc;
using CateringCo.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
            var vm = new MenuItemListViewModel
            {
                MenuItems = menuItems,
                PageTitle = "Menu Items",
                TotalCount = menuItems.Count,
                EmptyMessage = "No menu items available."
                };
            return View(vm);
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

        // Week six
        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            return View();
        }
    }
}
