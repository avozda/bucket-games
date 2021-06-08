using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bucket_games.Data;
using bucket_games.Models;

namespace bucket_games.Controllers
{
    public class HraController : Controller
    {
        private readonly bucket_gamesContext _context;

        public HraController(bucket_gamesContext context)
        {
            _context = context;
        }

        // GET: Hra
        public async Task<IActionResult> Index(string movieGenre, string Vyhledávání)
        {

            _context.Database.EnsureCreated();

            IQueryable<string> genreQuery = from m in _context.Hra
                                            orderby m.Žánr
                                            select m.Žánr;

            var hry = from m in _context.Hra
                         select m;

            if (!string.IsNullOrEmpty(Vyhledávání))
            {
                hry = hry.Where(s => s.Název.Contains(Vyhledávání));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                hry = hry.Where(x => x.Žánr == movieGenre);
            }

            var movieGenreVM = new HraŽánrViewModel
            {
                Žánry = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Hry = await hry.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Hra/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hra = await _context.Hra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hra == null)
            {
                return NotFound();
            }

            return View(hra);
        }

        // GET: Hra/Create  
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Název,Datum,Žánr,Cena")] Hra hra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hra);
        }

        // GET: Hra/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hra = await _context.Hra.FindAsync(id);
            if (hra == null)
            {
                return NotFound();
            }
            return View(hra);
        }

        // POST: Hra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Název,Datum,Žánr,Cena")] Hra hra)
        {
            if (id != hra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HraExists(hra.Id))
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
            return View(hra);
        }

        // GET: Hra/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hra = await _context.Hra
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hra == null)
            {
                return NotFound();
            }

            return View(hra);
        }

        // POST: Hra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hra = await _context.Hra.FindAsync(id);
            _context.Hra.Remove(hra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HraExists(int id)
        {
            return _context.Hra.Any(e => e.Id == id);
        }
    }
}
