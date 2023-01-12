using Microsoft.AspNetCore.Mvc;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CodecampN3Context _db;
        public CategoryController(CodecampN3Context db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
    }
}
