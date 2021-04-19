using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ASPProject.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AnimesController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AnimesController(Context context , UserManager<ApplicationUser> user , IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            userManager = user;
            this.webHostEnvironment = webHostEnvironment;
        }

        // GET: Animes
        [AllowAnonymous]
        [Authorize(Roles ="Client")]
        public async Task<IActionResult> MyList()
        {
            List<Anime> animes = new List<Anime>();
            if (User.Identity.IsAuthenticated)
            {
            var user= await userManager.FindByIdAsync( userManager.GetUserId(User));
              var useranimes =  _context.UsersAnime.Where(oo=>oo.UserID==user.Id).ToList();

                foreach (var item in useranimes)
                {
                    animes.Add(_context.Anime.FirstOrDefault(oo=>oo.ID==item.AnimeID));
                }
            }
            return View(animes);
        }

        public async Task<IActionResult> Index ()
        {

            return View(await _context.Anime.ToListAsync());
        }

        // GET: Animes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await userManager.GetUserAsync(User);
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime
                .FirstOrDefaultAsync(m => m.ID == id);
          var x =   _context.UsersAnime.FirstOrDefault(f=>f.AnimeID == id && f.UserID == user.Id);
            ViewBag.checklike = x;
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Anime anime)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(anime.ImageFile.FileName);
                string extension = Path.GetExtension(anime.ImageFile.FileName);
                anime.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await anime.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(anime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anime);
        }        
        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var anime = await _context.Anime.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            return View(anime);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Anime anime)
        {
            if (id != anime.ID)
            {
                return NotFound();
            }
            if (anime.ImageFile != null || anime.ImageFile.Length != 0)
            {
                var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", anime.ImageName);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                string wwwRootPath = webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(anime.ImageFile.FileName);
                string extension = Path.GetExtension(anime.ImageFile.FileName);
                anime.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await anime.ImageFile.CopyToAsync(fileStream);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeExists(anime.ID))
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
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime
                .FirstOrDefaultAsync(m => m.ID == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anime = await _context.Anime.FindAsync(id);
            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", anime.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _context.Anime.Remove(anime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
            return _context.Anime.Any(e => e.ID == id);
        }
    }
}
