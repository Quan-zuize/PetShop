using Microsoft.AspNetCore.Mvc;
using PetShop.Service.Products;

namespace PetShop.Controllers
{
    public class ServiceController : Controller
    {
        public ProductService Services;
        public ServiceController(ProductService services)
        {
            Services = services;
        }

        public IActionResult Index(int id)
        {
            //var getServiceById = Services.GetById(id); 
            //return View(getServiceById);
            @ViewBag.active_service = "active";
            return View();
        }

        // GET: Products/Delete/5
        public IActionResult Details(int? id)
        {
            if (id == null || Services == null)
            {
                return NotFound();
            }

            var product = Services.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
