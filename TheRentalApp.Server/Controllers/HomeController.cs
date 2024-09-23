using Microsoft.AspNetCore.Mvc;

namespace TheRentalApp.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
