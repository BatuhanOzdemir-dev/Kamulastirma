using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kamulastirma.Models;

namespace Kamulastirma.Controllers
{
    public class KisilerController : Controller
    {
        private readonly KamulastirmaContext _context;

        public KisilerController(KamulastirmaContext context)
        {
            _context = context;
        }

        // GET: Kisiler
        public async Task<IActionResult> Index()
        {
              return View(await _context.Kisilers.ToListAsync());
        }

        // GET: Kisiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kisilers == null)
            {
                return NotFound();
            }

            var kisiler = await _context.Kisilers
                .FirstOrDefaultAsync(m => m.KisiId == id);
            if (kisiler == null)
            {
                return NotFound();
            }

            return View(kisiler);
        }

        // GET: Kisiler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kisiler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kisiler kisiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kisiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kisiler);
        }

        // GET: Kisiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kisilers == null)
            {
                return NotFound();
            }

            var kisiler = await _context.Kisilers.FindAsync(id);
            if (kisiler == null)
            {
                return NotFound();
            }
            return View(kisiler);
        }

        // POST: Kisiler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Kisiler kisiler)
        {
            if (id != kisiler.KisiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kisiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KisilerExists(kisiler.KisiId))
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
            return View(kisiler);
        }

        // GET: Kisiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kisilers == null)
            {
                return NotFound();
            }

            var kisiler = await _context.Kisilers
                .FirstOrDefaultAsync(m => m.KisiId == id);
            if (kisiler == null)
            {
                return NotFound();
            }

            return View(kisiler);
        }

        // POST: Kisiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kisilers == null)
            {
                return Problem("Entity set 'KamulastirmaContext.Kisilers'  is null.");
            }
            var kisiler = await _context.Kisilers.FindAsync(id);
            if (kisiler != null)
            {
                _context.Kisilers.Remove(kisiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KisilerExists(int id)
        {
          return _context.Kisilers.Any(e => e.KisiId == id);
        }
    }
}
