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

        public async Task<IActionResult> Index(int id)
        {
            var getServiceById = Services.GetById(id); 
            return View();
        }
    }
}
