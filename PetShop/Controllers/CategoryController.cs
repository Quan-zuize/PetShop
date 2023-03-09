using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Service.Categories;
using PetShop.Service.Products;

namespace PetShop.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryService _categoryService;
        private readonly CodecampN3Context _context;
        public CategoryController(CategoryService categoryService, CodecampN3Context context)
        {
            _categoryService = categoryService;
            _context = context;
        }
        public IActionResult Index()
        {
            var categoryList = new GetCategory
            {
                categories = _categoryService.GetAll().ToList()
            };
            
            //ViewBag.Products = categoryList;
            return View(categoryList);
        }
    }
    public class GetCategory
    {
        public List<Category> categories { get; set; }
    }
}
