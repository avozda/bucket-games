using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bucket_games.Data;
using bucket_games.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;

namespace bucket_games.Controllers
{
    public class HraController : Controller
    {
        private readonly bucket_gamesContext _context;
        public HraController(bucket_gamesContext context)
        {
            _context = context;
        }

        public IHostingEnvironment _hostingEnvironment;

        // GET: Hra
        public async Task<IActionResult> Index(string HerníŽánr, string Vyhledávání)
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

            if (!string.IsNullOrEmpty(HerníŽánr))
            {
                hry = hry.Where(x => x.Žánr == HerníŽánr);
            }

            SelectList sl = new SelectList(await genreQuery.Distinct().ToListAsync());
            List<Hra> l = hry.ToList();

            Console.WriteLine("sl: " + sl);
            Console.WriteLine("l: " + l);

            var movieGenreVM = new HraŽánrViewModel
            {
                Žánry = sl,
                Hry = l
            };

            return View(movieGenreVM);
        }

        [Obsolete]
        [HttpPost]
        public async Task<IActionResult> Index(IList<IFormFile> files)
        {
            foreach (var file in files)
            {
                string fileName = ContentDispositionHeaderValue
                    .Parse(file.ContentDisposition)
                    .FileName.ToString().Trim('"');

                if (fileName.EndsWith(".txt"))
                {
                    var filePath = _hostingEnvironment.ContentRootPath + "\\wwwroot\\" + fileName;
                    await using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return RedirectToAction("Index");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Název,Datum,Žánr,Cena,Fotka")] Hra hra)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Název,Datum,Žánr,Cena,Fotka")] Hra hra)
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

        [HttpPost]
        public ActionResult UploadFiles(IFormFile file)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //Method 2 Get file details from HttpPostedFileBase class    

                    if (file != null)
                    {
                        string path = Path.Combine("~/UploadedFiles", Path.GetFileName(file.FileName));
                        using Stream fileStream = new FileStream(path, FileMode.Create);
                        file.CopyTo(fileStream);
                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading."; ;
                }
            }
            return View("Index");
        }

        private bool HraExists(int id)
        {
            return _context.Hra.Any(e => e.Id == id);
        }
    }
}
