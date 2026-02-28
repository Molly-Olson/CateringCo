using Microsoft.AspNetCore.Mvc;
using CateringCo.Models;


namespace CateringCo.Controllers
{
    public class CateringRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CateringRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("Confirmation");
        }
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
