using Microsoft.AspNetCore.Mvc;

namespace CateringCo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Admin/Info")]
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
