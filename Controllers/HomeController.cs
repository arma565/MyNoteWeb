using Microsoft.AspNetCore.Mvc;

namespace Note.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Click Notes to see and manage notes";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact() {
            return View();
        }
    }
}
