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
    public class MulkiyetBilgileriController : Controller
    {
        private readonly KamulastirmaContext _context;

        public MulkiyetBilgileriController(KamulastirmaContext context)
        {
            _context = context;
        }

        // GET: MulkiyetBilgileri
        public async Task<IActionResult> Index()
        {
            var kamulastirmaContext = _context.MulkiyetBilgileris;
            return View(await kamulastirmaContext.ToListAsync());
        }

        // GET: MulkiyetBilgileri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MulkiyetBilgileris == null)
            {
                return NotFound();
            }

            var mulkiyetBilgileri = await _context.MulkiyetBilgileris
                .FirstOrDefaultAsync(m => m.MulkiyetId == id);
            if (mulkiyetBilgileri == null)
            {
                return NotFound();
            }

            return View(mulkiyetBilgileri);
        }

        // GET: MulkiyetBilgileri/Create
        public IActionResult Create()
        {
            ViewData["AnalizId"] = new SelectList(_context.MulkiyetAnalizs, "AnalizId", "AnalizId");
            return View();
        }

        // POST: MulkiyetBilgileri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MulkiyetId,AnalizId,TahsisMetrekare,TahsisBorcuVarmi,Etap,KonutMetrekare,BorcluAlacakli,BorcPesinTaksit,BorcluSicil,MetrekareBedeli,ToplamOdeme")] MulkiyetBilgileri mulkiyetBilgileri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mulkiyetBilgileri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mulkiyetBilgileri);
        }

        // GET: MulkiyetBilgileri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MulkiyetBilgileris == null)
            {
                return NotFound();
            }

            var mulkiyetBilgileri = await _context.MulkiyetBilgileris.FindAsync(id);
            if (mulkiyetBilgileri == null)
            {
                return NotFound();
            }
            return View(mulkiyetBilgileri);
        }

        // POST: MulkiyetBilgileri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MulkiyetId,AnalizId,TahsisMetrekare,TahsisBorcuVarmi,Etap,KonutMetrekare,BorcluAlacakli,BorcPesinTaksit,BorcluSicil,MetrekareBedeli,ToplamOdeme")] MulkiyetBilgileri mulkiyetBilgileri)
        {
            if (id != mulkiyetBilgileri.MulkiyetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mulkiyetBilgileri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MulkiyetBilgileriExists(mulkiyetBilgileri.MulkiyetId))
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
            return View(mulkiyetBilgileri);
        }

        // GET: MulkiyetBilgileri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MulkiyetBilgileris == null)
            {
                return NotFound();
            }

            var mulkiyetBilgileri = await _context.MulkiyetBilgileris
                .FirstOrDefaultAsync(m => m.MulkiyetId == id);
            if (mulkiyetBilgileri == null)
            {
                return NotFound();
            }

            return View(mulkiyetBilgileri);
        }

        // POST: MulkiyetBilgileri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MulkiyetBilgileris == null)
            {
                return Problem("Entity set 'KamulastirmaContext.MulkiyetBilgileris'  is null.");
            }
            var mulkiyetBilgileri = await _context.MulkiyetBilgileris.FindAsync(id);
            if (mulkiyetBilgileri != null)
            {
                _context.MulkiyetBilgileris.Remove(mulkiyetBilgileri);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MulkiyetBilgileriExists(int id)
        {
            return _context.MulkiyetBilgileris.Any(e => e.MulkiyetId == id);
        }
    }
}
