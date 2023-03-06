using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Service.BannerImage.ViewModel;
using PetShop.Service.CauHinhs;
using PetShop.Service.Products;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ProductService _productService;
        public CauHinhService _cauHinhService;
        public BannerImageService _bannerImageService;
        public HomeController(ILogger<HomeController> logger, ProductService productService, CauHinhService cauHinhService, BannerImageService bannerImageService )
        {
            _logger = logger;
            _productService = productService;
            _cauHinhService= cauHinhService;
            _bannerImageService = bannerImageService;
        }

        public IActionResult Index()
        {
            @ViewBag.active_index = "active";
            ViewData["getAllServices"] = _productService.GetAllServices();
            ViewData["getAllProducts"] = _productService.GetAll();
            
            ViewBag.Logo = _cauHinhService.GetCauHinhByTenCauHinh("Logo").GiaTriCauHinh;
            ViewBag.Brand = _cauHinhService.GetCauHinhByTenCauHinh("Brand").GiaTriCauHinh;

            TempData["AboutTitle"]= _cauHinhService.GetCauHinhByTenCauHinh("AboutTitle").GiaTriCauHinh;
            TempData["AboutShortDes"] = _cauHinhService.GetCauHinhByTenCauHinh("AboutShortDescription").GiaTriCauHinh;
            TempData["AboutImg"] = _cauHinhService.GetCauHinhByTenCauHinh("AboutImg").GiaTriCauHinh;
            TempData["AboutMission"] = _cauHinhService.GetCauHinhByTenCauHinh("AboutMission").GiaTriCauHinh;
            TempData["AboutVision"] = _cauHinhService.GetCauHinhByTenCauHinh("AboutVision").GiaTriCauHinh;
            

            TempData["Office"] = _cauHinhService.GetCauHinhByTenCauHinh("Office").GiaTriCauHinh;
            TempData["EmailContact"] = _cauHinhService.GetCauHinhByTenCauHinh("EmailContact").GiaTriCauHinh;
            TempData["PhoneNum"] = _cauHinhService.GetCauHinhByTenCauHinh("PhoneNum").GiaTriCauHinh;
            TempData.Keep();
            ViewBag.HomeBanner = _bannerImageService.GetAll();
            return View();
        }
        public IActionResult About()
        {
            TempData.Keep("AboutTitle");
            TempData.Keep("AboutShortDes");
            TempData.Keep("AboutImg");
            TempData.Keep("AboutMission");
            TempData.Keep("AboutVision");

            TempData.Keep("Office");
            TempData.Keep("EmailContact");
            TempData.Keep("PhoneNum");

            @ViewBag.active_about = "active";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
