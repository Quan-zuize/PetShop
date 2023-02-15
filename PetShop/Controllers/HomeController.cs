using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CodecampN3Context db = new CodecampN3Context();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            @ViewBag.active_index = "active";


            return View();
        }

        public IActionResult Product()
        {
            @ViewBag.active_product = "active";
            return View();
        }

        public IActionResult Service()
        {

            @ViewBag.active_service = "active";
            return View();
        }
        public IActionResult About()
        {
            @ViewBag.active_about = "active";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}