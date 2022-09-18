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
    public class VrsteatributumsController : Controller
    {
        private readonly ZadatakContext _context;

        public VrsteatributumsController(ZadatakContext context)
        {
            _context = context;
        }

        // GET: Vrsteatributums
        public async Task<IActionResult> Index()
        {
              return View(await _context.Vrsteatributa.ToListAsync());
        }

        // GET: Vrsteatributums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vrsteatributa == null)
            {
                return NotFound();
            }

            var vrsteatributum = await _context.Vrsteatributa
                .FirstOrDefaultAsync(m => m.Vrstaatributaid == id);
            if (vrsteatributum == null)
            {
                return NotFound();
            }

            return View(vrsteatributum);
        }

        // GET: Vrsteatributums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vrsteatributums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vrstaatributaid,Vrstaatributanaziv")] Vrsteatributum vrsteatributum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vrsteatributum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vrsteatributum);
        }

        // GET: Vrsteatributums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vrsteatributa == null)
            {
                return NotFound();
            }

            var vrsteatributum = await _context.Vrsteatributa.FindAsync(id);
            if (vrsteatributum == null)
            {
                return NotFound();
            }
            return View(vrsteatributum);
        }

        // POST: Vrsteatributums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Vrstaatributaid,Vrstaatributanaziv")] Vrsteatributum vrsteatributum)
        {
            if (id != vrsteatributum.Vrstaatributaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vrsteatributum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VrsteatributumExists(vrsteatributum.Vrstaatributaid))
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
            return View(vrsteatributum);
        }

        // GET: Vrsteatributums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vrsteatributa == null)
            {
                return NotFound();
            }

            var vrsteatributum = await _context.Vrsteatributa
                .FirstOrDefaultAsync(m => m.Vrstaatributaid == id);
            if (vrsteatributum == null)
            {
                return NotFound();
            }

            return View(vrsteatributum);
        }

        // POST: Vrsteatributums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vrsteatributa == null)
            {
                return Problem("Entity set 'ZadatakContext.Vrsteatributa'  is null.");
            }
            var vrsteatributum = await _context.Vrsteatributa.FindAsync(id);
            if (vrsteatributum != null)
            {
                _context.Vrsteatributa.Remove(vrsteatributum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VrsteatributumExists(int id)
        {
          return _context.Vrsteatributa.Any(e => e.Vrstaatributaid == id);
        }
    }
}
