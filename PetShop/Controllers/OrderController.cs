using Microsoft.AspNetCore.Mvc;

namespace PetShop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
