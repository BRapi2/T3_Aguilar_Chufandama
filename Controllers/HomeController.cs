using Microsoft.AspNetCore.Mvc;

namespace T3_Aguilar_Chufandama.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Arquitectura()
        {
            return View();
        }

        public IActionResult Diseno()
        {
            return View();
        }
    }
}
