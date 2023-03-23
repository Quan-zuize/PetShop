using System;
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
    public class CauHinhsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CauHinhsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CauHinhs
        public async Task<IActionResult> Index()
        {
              return View(await _context.CauHinh.ToListAsync());
        }

        // GET: CauHinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CauHinh == null)
            {
                return NotFound();
            }

            var cauHinh = await _context.CauHinh
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cauHinh == null)
            {
                return NotFound();
            }

            return View(cauHinh);
        }

        // GET: CauHinhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CauHinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenCauHinh,GiaTriCauHinh,Id")] CauHinh cauHinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cauHinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cauHinh);
        }

        // GET: CauHinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CauHinh == null)
            {
                return NotFound();
            }

            var cauHinh = await _context.CauHinh.FindAsync(id);
            if (cauHinh == null)
            {
                return NotFound();
            }
            return View(cauHinh);
        }

        // POST: CauHinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenCauHinh,GiaTriCauHinh,Id")] CauHinh cauHinh)
        {
            if (id != cauHinh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cauHinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CauHinhExists(cauHinh.Id))
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
            return View(cauHinh);
        }

        // GET: CauHinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CauHinh == null)
            {
                return NotFound();
            }

            var cauHinh = await _context.CauHinh
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cauHinh == null)
            {
                return NotFound();
            }

            return View(cauHinh);
        }

        // POST: CauHinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CauHinh == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CauHinh'  is null.");
            }
            var cauHinh = await _context.CauHinh.FindAsync(id);
            if (cauHinh != null)
            {
                _context.CauHinh.Remove(cauHinh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CauHinhExists(int id)
        {
          return _context.CauHinh.Any(e => e.Id == id);
        }
    }
}
