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
using ASPProject.Services;

namespace ASPProject.Controllers
{
    public class AnimesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMangerServices<UsersAnime> userAnimeService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMangerServices<Anime> animeService;

        public AnimesController(UserManager<ApplicationUser> user, IMangerServices<UsersAnime> userAnimeService , IWebHostEnvironment webHostEnvironment,IMangerServices<Anime> animeService)
        {
            userManager = user;
            this.userAnimeService = userAnimeService;
            this.webHostEnvironment = webHostEnvironment;
            this.animeService = animeService;
        }

        private async Task<List<Anime>> sendStatus(WatchingStatus S)
        {
            List<Anime> anime = new List<Anime>();
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.FindByIdAsync(userManager.GetUserId(User));
                var useranimes = await userAnimeService.GetAll();
                var users=useranimes.Where(oo => oo.UserID == user.Id && oo.WatchingStatus == S).ToList();
                foreach (var item in users)
                {
                    //anime.Add(_context.Anime.FirstOrDefault(oo => oo.ID == item.AnimeID));
                    anime.Add(await animeService.GetDetails(item.AnimeID));
                }
            }
            return anime;
        }
        [HttpPost]
        [Authorize(Roles = "Client")]

        public async Task<IActionResult> MyList(int filter)
        {
            if (filter == 1)
            {
                return View(await sendStatus(WatchingStatus.Watching));
            }
            else if (filter == 2)
            {
                return View(await sendStatus(WatchingStatus.Completed));
            }
            else if (filter == 3)
            {
                return View(await sendStatus(WatchingStatus.On_Hold));
            }
            else if (filter == 4)
            {
                return View(await sendStatus(WatchingStatus.ToWatch));
            }
            else
            {
                return View(await sendStatus(WatchingStatus.Dropped));
            }
        }

        // GET: Animes
        [Authorize(Roles ="Client")]
        public async Task<IActionResult> MyList()
        {
            List<Anime> animes = new List<Anime>();
            if (User.Identity.IsAuthenticated)
            {
            var user= await userManager.FindByIdAsync( userManager.GetUserId(User));
                var useranimes = await userAnimeService.GetAll();
                var users=useranimes.Where(oo=>oo.UserID==user.Id).ToList();

                foreach (var item in users)
                {
                    // animes.Add(_context.Anime.FirstOrDefault(oo=>oo.ID==item.AnimeID));
                    animes.Add(await animeService.GetDetails(item.AnimeID));
                }
            }
            return View(animes);
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Index ()
        {

            //  return View(await _context.Anime.ToListAsync());
            return View(await animeService.GetAll());
        }

        // GET: Animes/Details/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Details(int id)
        {
            var user = await userManager.GetUserAsync(User);


            /*   var anime = await _context.Anime
                   .FirstOrDefaultAsync(m => m.ID == id);*/
            var anime = await animeService.GetDetails(id);
            var x = await userAnimeService.GetAll();
            var y=x.FirstOrDefault(f=>f.AnimeID == id && f.UserID == user.Id);
            ViewBag.checklike = x;
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: Animes/Create
        [Authorize(Roles = "Admin")]

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
                await animeService.Insert(anime);
                return RedirectToAction(nameof(Index));
            }
            return View(anime);
        }
        // GET: Animes/Edit/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(int id)
        {

            var anime = await animeService.GetDetails(id);
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
                   await animeService.Update(anime);
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
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {


            var anime = await animeService.GetDetails(id);
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
            var anime = await animeService.GetDetails(id);
            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "images", anime.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            await animeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private  bool AnimeExists(int id)
        {
            return  animeService.GetAllNotAsync().Any(e => e.ID == id);
        }
    }
}
