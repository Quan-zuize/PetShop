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
        public BannerImageService _bannerImageService;

        public ProductsController(ProductService productService,CategoryService category,BannerImageService bannerImageService)
        {
            _productService = productService;
            _categoryService = category;
            _bannerImageService = bannerImageService;
        }

        public const string CARTKEY = "cart";

        // GET: Products
        [Route("Product")]
        public IActionResult Index(string name, int id)
        {
            @ViewBag.active_product = "active";
            TempData.Keep("Office");
            TempData.Keep("EmailContact");
            TempData.Keep("PhoneNum");
            TempData.Keep("Brand");

            ViewBag.SpecialOffer = _bannerImageService.GetAll().ElementAt(1);

            var results = _productService.GetAll().ToList();

            if (!string.IsNullOrWhiteSpace(name))
            {
                id = 0;
                results = _productService.SearchProduct(name).ToList();
                ViewBag.Categories = "Our Products";
                ViewBag.Found = "Found " + results.Count + " product";
            }

            if (id == 0)
            {
                ViewBag.Products = results;
                ViewBag.Categories = "Our Products";
            }
            else
            {
                results = _productService.GetAllByCategory(id).ToList();
                ViewBag.Products = results;
                ViewBag.Categories = _categoryService.GetById(id).Name;
            }
            return View(results);
            //return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        [Route("ProductDetail")]
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

