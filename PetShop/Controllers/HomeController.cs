using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Service.Products;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ProductService ProductServices;
        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            ProductServices = productService;
        }

        public IActionResult Index()
        {
            @ViewBag.active_index = "active";
            var getAllServices = ProductServices.GettAllServices();
            return View(getAllServices);
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