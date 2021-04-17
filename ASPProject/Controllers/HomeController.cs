using ASPProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Controllers
{
    

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Context _context;
        private readonly UserManager<ApplicationUser> userManager;

     
        public HomeController(ILogger<HomeController> logger , Context context, UserManager<ApplicationUser> user)
        {
            _logger = logger;
            _context = context;
            userManager = user;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Anime.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var user = await userManager.GetUserAsync(User);
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime
                .FirstOrDefaultAsync(m => m.ID == id);
            var x = _context.UsersAnime.FirstOrDefault(f => f.AnimeID == id && f.UserID == user.Id);
            ViewBag.checklike = x;
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        public async Task<IActionResult> removefromList(int id)
        {
            UsersAnime usersAnime = new UsersAnime();
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(User);
                var x = _context.UsersAnime.FirstOrDefault(f => f.AnimeID == id && f.UserID == user.Id);

                if (user != null && x != null)
                {
                    _context.UsersAnime.Remove(x);
                    _context.SaveChanges();
                }
            }
            return Redirect("Details/" + id);
        }

        [HttpPost]
        public async Task<IActionResult> addtoList(int id)
        {
            UsersAnime usersAnime = new UsersAnime();
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(User);
                if (user != null)
                {
                    usersAnime.UserID = await userManager.GetUserIdAsync(user);
                    usersAnime.AnimeID = id;
                    usersAnime.Rating = 0;
                    _context.UsersAnime.Add(usersAnime);
                    _context.SaveChanges();
                }
            }
            return Redirect($"Details/{id}");
        }
        

            [HttpPost]
        public async Task<IActionResult> RateIT(int id ,  int Rating)
        {
            
            UsersAnime usersAnime = new UsersAnime();
            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.GetUserAsync(User);
                if (user != null)
                {
                    usersAnime.UserID = await userManager.GetUserIdAsync(user);
                    usersAnime.AnimeID = id;
                    usersAnime.Rating = Rating;
                    _context.UsersAnime.Update(usersAnime);
                    _context.SaveChanges();
                }
            }
            return Redirect($"Details/{id}");
        }

        public  IActionResult FilteredAnimes(string searchKey)
        {
           var x=  _context.Anime.Where(d => d.Name.StartsWith(searchKey)).ToList();
            return View(x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
