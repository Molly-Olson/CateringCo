using Microsoft.AspNetCore.Mvc;

namespace CateringCo.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
