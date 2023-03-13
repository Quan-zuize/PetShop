﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using PetShopAdmin.Data;

namespace PetShopAdmin.Controllers
{
    public class BannerImagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BannerImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BannerImages
        public async Task<IActionResult> Index()
        {
              return View(await _context.BannerImage.ToListAsync());
        }

        // GET: BannerImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BannerImage == null)
            {
                return NotFound();
            }

            var bannerImage = await _context.BannerImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bannerImage == null)
            {
                return NotFound();
            }

            return View(bannerImage);
        }

        // GET: BannerImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BannerImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Link,SubTitle,Image,Title,Description,Id")] BannerImage bannerImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bannerImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bannerImage);
        }

        // GET: BannerImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BannerImage == null)
            {
                return NotFound();
            }

            var bannerImage = await _context.BannerImage.FindAsync(id);
            if (bannerImage == null)
            {
                return NotFound();
            }
            return View(bannerImage);
        }

        // POST: BannerImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Link,SubTitle,Image,Title,Description,Id")] BannerImage bannerImage)
        {
            if (id != bannerImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bannerImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerImageExists(bannerImage.Id))
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
            return View(bannerImage);
        }

        // GET: BannerImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BannerImage == null)
            {
                return NotFound();
            }

            var bannerImage = await _context.BannerImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bannerImage == null)
            {
                return NotFound();
            }

            return View(bannerImage);
        }

        // POST: BannerImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BannerImage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BannerImage'  is null.");
            }
            var bannerImage = await _context.BannerImage.FindAsync(id);
            if (bannerImage != null)
            {
                _context.BannerImage.Remove(bannerImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerImageExists(int id)
        {
          return _context.BannerImage.Any(e => e.Id == id);
        }
    }
}
