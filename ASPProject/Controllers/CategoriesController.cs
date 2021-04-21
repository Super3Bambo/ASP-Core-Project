using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASPProject.Controllers
{
   // [Authorize(Roles = "Admin")]

    public class CategoriesController : Controller
    {
        private readonly Context _context;

        public CategoriesController(Context context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }
        [AllowAnonymous]
        public async Task<IActionResult> AllCategories()
        {
            return View(await _context.Categories.ToListAsync());
        }
        [AllowAnonymous]
        public IActionResult CategoryAnime(int id) {

            var getCat = _context.Categories.FirstOrDefault(oo=>oo.ID==id);
            ViewBag.catName = getCat.Name;
            var getAnimes = _context.AnimeCategories.Where(oo=>oo.CategoryID==id);
            List<Anime> animes = new List<Anime>();
            foreach (var item in getAnimes)
            {
                var anime = _context.Anime.FirstOrDefault(oo => oo.ID == item.AnimeID);
                animes.Add(anime);
            }
            
            return View(animes);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Category category)
        {
            if (id != category.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.ID))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.ID == id);
        }

        public async Task<IActionResult> AddAnimes(int id)
        {
            var cat = _context.Categories.Find(id);
            var x = _context.AnimeCategories.Where(oo => oo.CategoryID == id).ToList();
            List<Anime> Memberanimes = new List<Anime>();
            List<GetCatAnimes> animes = new List<GetCatAnimes>();
            foreach (var item in x)
            {
                var y = _context.Anime.Find(item.AnimeID);
                if (y != null)
                {
                    var obj = new GetCatAnimes();
                    obj.CatName = cat.Name;
                    obj.CatID = item.CategoryID.ToString();
                    obj.AnimeID = y.ID.ToString();
                    obj.AnimeName = y.Name;
                    obj.IsSelected = true;
                    Memberanimes.Add(y);
                    animes.Add(obj);

                }

            }
            var notIn = await _context.Anime.ToListAsync();
            var NonMemberanimes = notIn.Except(Memberanimes).ToList();
            foreach (var item in NonMemberanimes)
            {
                var obj = new GetCatAnimes();
                obj.CatName = cat.Name;
                obj.CatID = cat.ID.ToString();
                obj.AnimeID = item.ID.ToString();
                obj.AnimeName = item.Name;
                obj.IsSelected = false;
                animes.Add(obj);
            }

            return View(animes);
        }

        [HttpPost]
        public  ActionResult AddAnimes( List< GetCatAnimes> model)
        {
           // int Catid =int.Parse( model[0].CatID);
            for(int i=0; i< model.Count;  i++)
            {
                var x = new AnimeCategory()
                {
                    AnimeID = int.Parse(model[i].AnimeID),
                    CategoryID = int.Parse(model[i].CatID)
                };
                var obj = _context.AnimeCategories.AsNoTracking().FirstOrDefault(oo=>oo.AnimeID==x.AnimeID&& oo.CategoryID==x.CategoryID);

                if (model[i].IsSelected && obj==null ) {
                    _context.AnimeCategories.Add(x);
                }
                else if (! model[i].IsSelected && obj != null) {
                   
                    _context.AnimeCategories.Remove(x);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("");


        }
    }
}
