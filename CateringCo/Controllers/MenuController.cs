using CateringCo.Services.Interfaces;
using CateringCo.Models;
using Microsoft.AspNetCore.Mvc;
using CateringCo.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace CateringCo.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public async Task<IActionResult> Index()
        {
                var menuItems = await _menuService.GetAllAsync();
                var vm = new MenuItemListViewModel
            {
                MenuItems = menuItems,
                PageTitle = "Menu Items",
                TotalCount = menuItems.Count,
                EmptyMessage = "No menu items available."
                };
            return View(vm);
        }
        //week eight
        [Route("Menu/Info")]
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        // this commented out section is why the details link broke!! But if I add it back in then this files code breaks because of the repeat Route
        //[Route("Menu/Info")]

        //public IActionResult Details()
        //{
        //    return View();
        //}

        // Week six
        [Authorize(Roles = "Admin")]
        public IActionResult Manage()
        {
            return View();
        }
    }
}
