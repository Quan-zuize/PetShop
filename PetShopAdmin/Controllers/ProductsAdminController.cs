﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using PetShopAdmin.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PetShopAdmin.Controllers
{
<<<<<<<< HEAD:PetShopAdmin/Controllers/ProductsAdminController.cs
    public class ProductsAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsAdminController(ApplicationDbContext context)
========
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
>>>>>>>> 967871991141b3f01825d62e82b1ef2075cd6ed6:PetShopAdmin/Controllers/ServicesController.cs
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
<<<<<<<< HEAD:PetShopAdmin/Controllers/ProductsAdminController.cs
              return View(await _context.Product.ToListAsync());
========
            var services_list = _context.Product.Where(s => s.ProductType.Equals("Service"));

              return services_list != null ? 
                          View(await services_list.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Product'  is null.");
>>>>>>>> 967871991141b3f01825d62e82b1ef2075cd6ed6:PetShopAdmin/Controllers/ServicesController.cs
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ProductType,Image,Price,OriginalPrice,Description,Specification,Id")] Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await imageFile.CopyToAsync(ms);
                        var imageBytes = ms.ToArray();
                        product.Image = Convert.ToBase64String(imageBytes);
                    }
                }
                product.ProductType = "Product";
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ProductType,Image,Price,OriginalPrice,Description,Specification,Id")] Product product, IFormFile imageFile)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await imageFile.CopyToAsync(ms);
                            var imageBytes = ms.ToArray();
                            product.Image = Convert.ToBase64String(imageBytes);
                        }
                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
<<<<<<<< HEAD:PetShopAdmin/Controllers/ProductsAdminController.cs
          return _context.Product.Any(e => e.Id == id);
========
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
>>>>>>>> 967871991141b3f01825d62e82b1ef2075cd6ed6:PetShopAdmin/Controllers/ServicesController.cs
        }
    }
}
