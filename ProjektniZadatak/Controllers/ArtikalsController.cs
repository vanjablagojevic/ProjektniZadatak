using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektniZadatak.Models;

namespace ProjektniZadatak.Controllers
{
    public class ArtikalsController : Controller
    {
        private readonly ZadatakContext _context;

        public ArtikalsController(ZadatakContext context)
        {
            _context = context;
        }

        // GET: Artikals
        public async Task<IActionResult> Index()
        {
            var zadatakContext = _context.Artikals.Include(a => a.Jedinicamjere);
            return View(await zadatakContext.ToListAsync());
        }

        // GET: Artikals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artikals == null)
            {
                return NotFound();
            }

            var artikal = await _context.Artikals
                .Include(a => a.Jedinicamjere)
                .FirstOrDefaultAsync(m => m.Artikalid == id);
            if (artikal == null)
            {
                return NotFound();
            }

            return View(artikal);
        }

        // GET: Artikals/Create
        public IActionResult Create()
        {
            ViewData["Jedinicamjereid"] = new SelectList(_context.Jedinicamjeres, nameof(Jedinicamjere.Jedinicamjereid), nameof(Jedinicamjere.Jedinicamjereskracenica));
            return View();
        }

        // POST: Artikals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Artikalid,Jedinicamjereid,Artikalsifra,Artikalnaziv")] Artikal artikal)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(artikal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Jedinicamjereid"] = new SelectList(_context.Jedinicamjeres, nameof(Jedinicamjere.Jedinicamjereid), nameof(Jedinicamjere.Jedinicamjereskracenica), artikal.Jedinicamjereid);
            return View(artikal);
        }

        // GET: Artikals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artikals == null)
            {
                return NotFound();
            }

            var artikal = await _context.Artikals.FindAsync(id);
            if (artikal == null)
            {
                return NotFound();
            }
            ViewData["Jedinicamjereid"] = new SelectList(_context.Jedinicamjeres, nameof(Jedinicamjere.Jedinicamjereid), nameof(Jedinicamjere.Jedinicamjereskracenica), artikal.Jedinicamjereid);
            return View(artikal);
        }

        // POST: Artikals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Artikalid,Jedinicamjereid,Artikalsifra,Artikalnaziv")] Artikal artikal)
        {
            if (id != artikal.Artikalid)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(artikal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtikalExists(artikal.Artikalid))
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
            ViewData["Jedinicamjereid"] = new SelectList(_context.Jedinicamjeres, nameof(Jedinicamjere.Jedinicamjereid), nameof(Jedinicamjere.Jedinicamjereskracenica), artikal.Jedinicamjereid);
            return View(artikal);
        }

        // GET: Artikals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artikals == null)
            {
                return NotFound();
            }

            var artikal = await _context.Artikals
                .Include(a => a.Jedinicamjere)
                .FirstOrDefaultAsync(m => m.Artikalid == id);
            if (artikal == null)
            {
                return NotFound();
            }

            return View(artikal);
        }

        // POST: Artikals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artikals == null)
            {
                return Problem("Entity set 'ZadatakContext.Artikals'  is null.");
            }
            var artikal = await _context.Artikals.FindAsync(id);
            if (artikal != null)
            {
                _context.Artikals.Remove(artikal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtikalExists(int id)
        {
          return _context.Artikals.Any(e => e.Artikalid == id);
        }
    }
}
