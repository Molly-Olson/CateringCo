using Microsoft.AspNetCore.Mvc;

namespace CateringCo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
