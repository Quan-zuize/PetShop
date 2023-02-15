using Microsoft.AspNetCore.Mvc;
using PetShop.Service.Products;

namespace PetShop.Controllers
{
    public class ServiceController : Controller
    {
        public ProductService _services;
        public ServiceController(ProductService services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            @ViewBag.active_service = "active";
            var getAllServices = _services.GetAllServices();
            return View(getAllServices);
        }

        // GET: Products/Delete/5
        public IActionResult Details(int? id)
        {
            if (id == null || _services == null)
            {
                return NotFound();
            }

            var getServiceById = _services.GetById(id);
            if (getServiceById == null)
            {
                return NotFound();
            }

            return View(getServiceById);
        }
    }
}
