using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using PetShop.Service.Products;
using System.Data.Entity.Core.Common.CommandTrees;
using Newtonsoft.Json;


namespace PetShop.Controllers
{
    public class ProductsController : Controller
    {
        public ProductService _productService;
        private readonly CodecampN3Context _context;

        public ProductsController(ProductService productService, CodecampN3Context context)
        {
            _productService = productService;
            _context = context;
        }


        // GET: Products
        public IActionResult Index(int id)
        {
            @ViewBag.active_product = "active";
            TempData.Keep("Office");
            TempData.Keep("EmailContact");
            TempData.Keep("PhoneNum");

            
            if(id == null)
            {
                var results = _productService.GetAll().ToList();
                ViewBag.Products = results;
                return View(results);
            }
            else
            {
                var results = _productService.GetAllByCategory(id).ToList();
                ViewBag.Products = results;
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

        [Route("addcart/{productid:int}", Name = "addcart")]
        public IActionResult AddToCart([FromRoute] int productid)
        {
            //not ok
            var product = _productService.GetById(productid);

            if (product == null)
            {
                return NotFound("Cart emty");
            }

            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                cartitem.quantity++;
            }
            else
            {
                cart.Add(new CartItem() { quantity = 1, product = product });
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }

        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }

        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.Id == productid);
            if (cartitem != null)
            {
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            return Ok();
        }

        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

        [Route("/checkout")]
        public IActionResult CheckOut()
        {
            return View();
        }

        public const string CARTKEY = "cart";

        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        public double TotalNumber()
        {
            List<CartItem> lCart = HttpContext.Session as List<CartItem>;
            if (lCart == null)
            {
                return 0;
            }
            return lCart.Sum(c => c.quantity);
        }

        //public ActionResult SubmitOrder()
        //{
        //    var cart = GetCartItems();
        //    if (cart == null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    Order order = new Order();
        //    order.OrderDate = DateTime.Now;
        //    order.OrderStatus = "processing";

        //    List<CartItem> ls = GetCartItems();
        //    foreach(var item in ls) 
        //    {
        //        OrderDetail orderDetail = new OrderDetail();
        //        orderDetail.OrderId = order.Id;
        //        orderDetail.ProductId = item.product.Id;
        //        orderDetail.Description= item.product.Description;

        //    }
        //    return RedirectToAction("cart");
        //}

    }
}
