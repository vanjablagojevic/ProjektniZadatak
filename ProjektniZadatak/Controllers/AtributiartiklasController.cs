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
    public class AtributiartiklasController : Controller
    {
        private readonly ZadatakContext _context;

        public AtributiartiklasController(ZadatakContext context)
        {
            _context = context;
        }

        // GET: Atributiartiklas
        public async Task<IActionResult> Index(string searchString)
        {
            var zadatakContext = _context.Atributiartiklas.Include(a => a.Artikal).Include(a => a.Vrstaatributa);
            if (!String.IsNullOrEmpty(searchString))
            {
                zadatakContext = zadatakContext.Where(s => s.Vrstaatributa.Vrstaatributanaziv!.Contains(searchString) || s.Vrijednostatributa!.Contains(searchString) || s.Artikal.Artikalnaziv!.Contains(searchString) || s.Artikal.Artikalsifra!.Contains(searchString)).Include(a => a.Vrstaatributa);
            }

            return View(await zadatakContext.ToListAsync());
        }

        // GET: Atributiartiklas/Details/5
        public async Task<IActionResult> Details(int? id, int? id2)
        {
            if (id == null || _context.Atributiartiklas == null || id2 == null)
            {
                return NotFound();
            }

            var atributiartikla = await _context.Atributiartiklas
                .Include(a => a.Artikal)
                .Include(a => a.Vrstaatributa)
                .FirstOrDefaultAsync(m => m.Artikalid == id && m.Vrstaatributaid == id2);
            if (atributiartikla == null)
            {
                return NotFound();
            }

            return View(atributiartikla);
        }

        // GET: Atributiartiklas/Create
        public IActionResult Create()
        {
            ViewData["Artikalid"] = new SelectList(_context.Artikals, nameof(Artikal.Artikalid), nameof(Artikal.Artikalnaziv));
            ViewData["Vrstaatributaid"] = new SelectList(_context.Vrsteatributa, nameof(Vrsteatributum.Vrstaatributaid), nameof(Vrsteatributum.Vrstaatributanaziv));
            return View();
        }

        // POST: Atributiartiklas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Artikalid,Vrstaatributaid,Vrijednostatributa")] Atributiartikla atributiartikla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atributiartikla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Artikalid"] = new SelectList(_context.Artikals, nameof(Artikal.Artikalid), nameof(Artikal.Artikalnaziv), atributiartikla.Artikalid);
            ViewData["Vrstaatributaid"] = new SelectList(_context.Vrsteatributa, nameof(Vrsteatributum.Vrstaatributaid), nameof(Vrsteatributum.Vrstaatributanaziv), atributiartikla.Vrstaatributaid);
            return View(atributiartikla);
        }

        // GET: Atributiartiklas/Edit/5
        public async Task<IActionResult> Edit(int? id,int? id2)
        {
            if (id == null || _context.Atributiartiklas == null || id2==null)
            {
                return NotFound();
            }

            var atributiartikla = await _context.Atributiartiklas.FindAsync(id,id2);
            if (atributiartikla == null)
            {
                return NotFound();
            }
            ViewData["Artikalid"] = new SelectList(_context.Artikals, "Artikalid", "Artikalid", atributiartikla.Artikalid);
            ViewData["Vrstaatributaid"] = new SelectList(_context.Vrsteatributa, "Vrstaatributaid", "Vrstaatributaid", atributiartikla.Vrstaatributaid);
            return View(atributiartikla);
        }

        // POST: Atributiartiklas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,int id2, [Bind("Artikalid,Vrstaatributaid,Vrijednostatributa")] Atributiartikla atributiartikla)
        {
            if (id != atributiartikla.Artikalid && id2!= atributiartikla.Vrstaatributaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atributiartikla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtributiartiklaExists(atributiartikla.Artikalid))
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
            ViewData["Artikalid"] = new SelectList(_context.Artikals, "Artikalid", "Artikalid", atributiartikla.Artikalid);
            ViewData["Vrstaatributaid"] = new SelectList(_context.Vrsteatributa, "Vrstaatributaid", "Vrstaatributaid", atributiartikla.Vrstaatributaid);
            return View(atributiartikla);
        }

        // GET: Atributiartiklas/Delete/5
        public async Task<IActionResult> Delete(int? id,int? id2)
        {
            if (id == null || _context.Atributiartiklas == null)
            {
                return NotFound();
            }

            var atributiartikla = await _context.Atributiartiklas
                .Include(a => a.Artikal)
                .Include(a => a.Vrstaatributa)
                .FirstOrDefaultAsync(m => m.Artikalid == id && m.Vrstaatributaid==id2);
            if (atributiartikla == null)
            {
                return NotFound();
            }

            return View(atributiartikla);
        }

        // POST: Atributiartiklas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,int id2)
        {
            if (_context.Atributiartiklas == null)
            {
                return Problem("Entity set 'ZadatakContext.Atributiartiklas'  is null.");
            }
            var atributiartikla = await _context.Atributiartiklas.FindAsync(id,id2);
            if (atributiartikla != null)
            {
                _context.Atributiartiklas.Remove(atributiartikla);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtributiartiklaExists(int id)
        {
          return _context.Atributiartiklas.Any(e => e.Artikalid == id);
        }
    }
}
