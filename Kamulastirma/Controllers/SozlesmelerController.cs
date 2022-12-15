using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kamulastirma.Models;
using Kamulastirma.ViewModels;

namespace Kamulastirma.Controllers
{
    public class SozlesmelerController : Controller
    {
        private readonly KamulastirmaContext _context;

        public SozlesmelerController(KamulastirmaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ButunSozlesmeler()
        {
            var kamulastirmaContext = _context.Sozlesmelers.Include(s => s.Kisi).Include(s => s.Mulkiyet).Include(s => s.SozlesmeTuru);
            return View(await kamulastirmaContext.ToListAsync());
        }

        public async Task<IActionResult> ArsaSozlesmeler()
        {
            var kamulastirmaContext = _context.Sozlesmelers.Include(s => s.Kisi).Include(s => s.Mulkiyet).Include(s => s.SozlesmeTuru)
                                        .Where(s => s.SozlesmeTuru.SozlesmeTuruId == 1);
            return View("ButunSozlesmeler", await kamulastirmaContext.ToListAsync());
        }

        public async Task<IActionResult> TesisArsaSozlesmeler()
        {
            var kamulastirmaContext = _context.Sozlesmelers.Include(s => s.Kisi).Include(s => s.Mulkiyet).Include(s => s.SozlesmeTuru)
                                        .Where(s => s.SozlesmeTuru.SozlesmeTuruId == 2);
            return View("ButunSozlesmeler", await kamulastirmaContext.ToListAsync());
        }

        //public IActionResult SozlesmeOlustur()
        //{
        //    SozlesmeVM vm = new SozlesmeVM()
        //    {
        //        SozlesmeTurleri = _context.SozlesmeTurleris.ToList()
        //    };
        //    vm.SozlesmeTurSelectList = new SelectList(vm.SozlesmeTurleri, "SozlesmeTuruId", "SozlesmeTuru", 2);
        //    return View(vm);
        //}

        public IActionResult SozlesmeOlustur(int id)
        {

            TempData["SozlesmeTuruId"] = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SozlesmeOlustur(SozlesmeVM vm)
        {
            SozlesmeVM _vm = new SozlesmeVM()
            {
                Sozlesmeler = new Sozlesmeler()
                {
                    SozlesmeTuruId = (int?)TempData["SozlesmeTuruId"]
                },
                MulkiyetBilgileri = vm.MulkiyetBilgileri,
                Kisi = vm.Kisi
            };
            if (ModelState.IsValid && _vm.Sozlesmeler.SozlesmeTuruId != null)
            {
                //Mülkiyet Bilgileri veritabanına kaydedildi.
                _context.Add(_vm.MulkiyetBilgileri);
                _context.SaveChanges();
                //SaveChanges ile MulkiyetBilgileri modelimize MulkiyetId alınmış oldu.
                TempData["MulkiyetId"]= _vm.MulkiyetBilgileri.MulkiyetId;

                //Modelin MulkiyetId'si ayarlandı.
                _vm.Sozlesmeler.MulkiyetId = _vm.MulkiyetBilgileri.MulkiyetId;
                _context.Add(_vm.Sozlesmeler);
                _context.SaveChanges();

                //Kişi modelimizle sözleşme ilişkilendirildi.
                _vm.Kisi.Sozlesmelers.Add(_vm.Sozlesmeler);
                try{
                    //Veritabanında aynı TC'ye sahip biri varsa bulunup sözleşme ile ilişkilendirildi.
                    _context.Kisilers.First(k => k.TckimlikNo == _vm.Kisi.TckimlikNo).Sozlesmelers.Add(_vm.Sozlesmeler);
                }
                catch
                {
                    //Kişi veritabanında yoksa yenisi oluşturuldu.
                    _context.Add(_vm.Kisi);
                }
                finally
                {
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Edit), new { id = _vm.Sozlesmeler.SozlesmeId });

            }
            return View(_vm);
        }

        public async Task<IActionResult> Index()
        {
            var kamulastirmaContext = _context.Sozlesmelers.Include(s => s.Kisi).Include(s => s.Mulkiyet).Include(s => s.SozlesmeTuru);
            return View(await kamulastirmaContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sozlesmelers == null)
            {
                return NotFound();
            }

            var sozlesmeler = await _context.Sozlesmelers
                .Include(s => s.Kisi)
                .Include(s => s.Mulkiyet)
                .Include(s => s.SozlesmeTuru)
                .FirstOrDefaultAsync(m => m.SozlesmeId == id);
            if (sozlesmeler == null)
            {
                return NotFound();
            }

            return View(sozlesmeler);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sozlesmelers == null)
            {
                return NotFound();
            }

            var sozlesmeler = await _context.Sozlesmelers.FindAsync(id);
            if (sozlesmeler == null)
            {
                return NotFound();
            }
            ViewData["KisiId"] = new SelectList(_context.Kisilers, "KisiId", "KisiId", sozlesmeler.KisiId);
            ViewData["MulkiyetId"] = new SelectList(_context.MulkiyetBilgileris, "MulkiyetId", "MulkiyetId", sozlesmeler.MulkiyetId);
            ViewData["SozlesmeTuruId"] = new SelectList(_context.SozlesmeTurleris, "SozlesmeTuruId", "SozlesmeTuruId", sozlesmeler.SozlesmeTuruId);
            return View(sozlesmeler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SozlesmeId,SozlesmeTuruId,MulkiyetId,KisiId,KonutTeslimiId,ProjeId")] Sozlesmeler sozlesmeler)
        {
            if (id != sozlesmeler.SozlesmeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sozlesmeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SozlesmelerExists(sozlesmeler.SozlesmeId))
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
            ViewData["KisiId"] = new SelectList(_context.Kisilers, "KisiId", "KisiId", sozlesmeler.KisiId);
            ViewData["MulkiyetId"] = new SelectList(_context.MulkiyetBilgileris, "MulkiyetId", "MulkiyetId", sozlesmeler.MulkiyetId);
            ViewData["SozlesmeTuruId"] = new SelectList(_context.SozlesmeTurleris, "SozlesmeTuruId", "SozlesmeTuruId", sozlesmeler.SozlesmeTuruId);
            return View(sozlesmeler);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sozlesmelers == null)
            {
                return NotFound();
            }

            var sozlesmeler = await _context.Sozlesmelers
                .Include(s => s.Kisi)
                .Include(s => s.Mulkiyet)
                .Include(s => s.SozlesmeTuru)
                .FirstOrDefaultAsync(m => m.SozlesmeId == id);
            if (sozlesmeler == null)
            {
                return NotFound();
            }

            return View(sozlesmeler);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sozlesmelers == null)
            {
                return Problem("Entity set 'KamulastirmaContext.Sozlesmelers'  is null.");
            }
            var sozlesmeler = await _context.Sozlesmelers.FindAsync(id);
            if (sozlesmeler != null)
            {
                _context.Sozlesmelers.Remove(sozlesmeler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SozlesmelerExists(int id)
        {
            return _context.Sozlesmelers.Any(e => e.SozlesmeId == id);
        }
    }
}
