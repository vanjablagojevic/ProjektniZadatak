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
    public class JedinicamjeresController : Controller
    {
        private readonly ZadatakContext _context;

        public JedinicamjeresController(ZadatakContext context)
        {
            _context = context;
        }

        // GET: Jedinicamjeres
        public async Task<IActionResult> Index()
        {
              return View(await _context.Jedinicamjeres.ToListAsync());
        }

        // GET: Jedinicamjeres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Jedinicamjeres == null)
            {
                return NotFound();
            }

            var jedinicamjere = await _context.Jedinicamjeres
                .FirstOrDefaultAsync(m => m.Jedinicamjereid == id);
            if (jedinicamjere == null)
            {
                return NotFound();
            }

            return View(jedinicamjere);
        }

        // GET: Jedinicamjeres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jedinicamjeres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Jedinicamjereid,Jedinicamjerenaziv,Jedinicamjereskracenica")] Jedinicamjere jedinicamjere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jedinicamjere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jedinicamjere);
        }

        // GET: Jedinicamjeres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Jedinicamjeres == null)
            {
                return NotFound();
            }

            var jedinicamjere = await _context.Jedinicamjeres.FindAsync(id);
            if (jedinicamjere == null)
            {
                return NotFound();
            }
            return View(jedinicamjere);
        }

        // POST: Jedinicamjeres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Jedinicamjereid,Jedinicamjerenaziv,Jedinicamjereskracenica")] Jedinicamjere jedinicamjere)
        {
            if (id != jedinicamjere.Jedinicamjereid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jedinicamjere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JedinicamjereExists(jedinicamjere.Jedinicamjereid))
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
            return View(jedinicamjere);
        }

        // GET: Jedinicamjeres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Jedinicamjeres == null)
            {
                return NotFound();
            }

            var jedinicamjere = await _context.Jedinicamjeres
                .FirstOrDefaultAsync(m => m.Jedinicamjereid == id);
            if (jedinicamjere == null)
            {
                return NotFound();
            }

            return View(jedinicamjere);
        }

        // POST: Jedinicamjeres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Jedinicamjeres == null)
            {
                return Problem("Entity set 'ZadatakContext.Jedinicamjeres'  is null.");
            }
            var jedinicamjere = await _context.Jedinicamjeres.FindAsync(id);
            if (jedinicamjere != null)
            {
                _context.Jedinicamjeres.Remove(jedinicamjere);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JedinicamjereExists(int id)
        {
          return _context.Jedinicamjeres.Any(e => e.Jedinicamjereid == id);
        }
    }
}
