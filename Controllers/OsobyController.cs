using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcEvidence.Data;
using MvcEvidence.Models;

namespace MvcEvidence.Controllers
{
    public class OsobyController : Controller
    {
        private readonly MvcOsobaContext _context;

        public OsobyController(MvcOsobaContext context)
        {
            _context = context;
        }

        // GET: Osoby
        public async Task<IActionResult> Index(string osobaPojistovna, string searchString)
        {
            if (_context.Osoba == null)
            {
                return Problem("Entity set 'MvcOsobaContext.Osoba' is null.");
            }

            // LINQ načtení pojišťoven z db
            IQueryable<string> pojistovnaQuery = from o in _context.Osoba
                                                orderby o.Pojistovna
                                                select o.Pojistovna;

            var osoby = from o in _context.Osoba
                        select o;

            if (!string.IsNullOrEmpty(searchString))
            {
                osoby = osoby.Where(s => s.Jmeno!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(osobaPojistovna))
            {
                osoby = osoby.Where(x => x.Pojistovna == osobaPojistovna);
            }

            var osobaPojistovnaVM = new OsobaPojistovnaViewModel
            {
                Pojistovny = new SelectList(await pojistovnaQuery.Distinct().ToListAsync()),
                Osoby = await osoby.ToListAsync()
            };

            return View(osobaPojistovnaVM);            
        }

        // GET: Osoby/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Osoba == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba
                .FirstOrDefaultAsync(o => o.Id == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // GET: Osoby/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Osoby/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jmeno,Prijmeni,Vek,Telefon,Pojistovna")] Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osoba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(osoba);
        }

        // GET: Osoby/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Osoba == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba.FindAsync(id);
            if (osoba == null)
            {
                return NotFound();
            }
            return View(osoba);
        }

        // POST: Osoby/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jmeno,Prijmeni,Vek,Telefon,Pojistovna")] Osoba osoba)
        {
            if (id != osoba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osoba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsobaExists(osoba.Id))
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
            return View(osoba);
        }

        // GET: Osoby/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Osoba == null)
            {
                return NotFound();
            }

            var osoba = await _context.Osoba
                .FirstOrDefaultAsync(o => o.Id == id);
            if (osoba == null)
            {
                return NotFound();
            }

            return View(osoba);
        }

        // POST: Osoby/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Osoba == null)
            {
                return Problem("Entity set 'MvcOsobaContext.Osoba'  is null.");
            }
            var osoba = await _context.Osoba.FindAsync(id);
            
            if (osoba != null)
            {
                _context.Osoba.Remove(osoba);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsobaExists(int id)
        {
          return (_context.Osoba?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
