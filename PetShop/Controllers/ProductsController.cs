using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShop.Models;
using PetShop.Service.BannerImage.ViewModel;
using PetShop.Service.Categories;
using PetShop.Service.Products;

namespace PetShop.Controllers
{
    public class ProductsController : Controller
    {
        public ProductService _productService;
        public CategoryService _categoryService;
        private readonly CodecampN3Context _context;
        public BannerImageService _bannerImageService;

        public ProductsController(ProductService productService,CategoryService category, CodecampN3Context context,BannerImageService bannerImageService)
        {
            _productService = productService;
            _categoryService = category;
            _context = context;
            _bannerImageService = bannerImageService;
        }

        public const string CARTKEY = "cart";

        // GET: Products
        public IActionResult Index(int id)
        {
            @ViewBag.active_product = "active";
            TempData.Keep("Office");
            TempData.Keep("EmailContact");
            TempData.Keep("PhoneNum");

            ViewBag.SpecialOffer = _bannerImageService.GetAll().ElementAt(1);


            if (id == 0)
            {
                var results = _productService.GetAll().ToList();
                ViewBag.Category = "Our Products";
                ViewBag.Products = results;
                ViewBag.Categories = "Our Products";
                return View(results);
            }
            else
            {
                var results = _productService.GetAllByCategory(id).ToList();
                ViewBag.Category = _categoryService.GetById(id).Name;
                ViewBag.Products = results;
                ViewBag.Categories = _categoryService.GetById(id).Name;
                return View(results);
            }
            
            //return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            var result = _productService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    }
}

