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

   // [Authorize(Roles = "Client")]

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
        //[Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            var user = await userManager.GetUserAsync(User);
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.checkPremium = false;
            var anime = await _context.Anime
                .FirstOrDefaultAsync(m => m.ID == id);
          var cats=  _context.AnimeCategories.Where(oo=>oo.AnimeID==anime.ID);
            List<Category> categories = new List<Category>();
            foreach (var item in cats)
            {
                var x = _context.Categories.FirstOrDefault(oo=>oo.ID==item.CategoryID);
                categories.Add(x);
            }


            ViewBag.Cats = categories;

            var anmes = _context.Anime.Where(oo => oo.Name.Contains(anime.Name.Substring(0,1)));

            List<Anime> animes = new List<Anime>();
            
                var anmList = _context.Anime.Where(oo => oo.ID != anime.ID).ToList();
            if (anmList.Count > 3) {
                for (int i = 0; i < 3; i++)
                {
                animes.Add(anmList[i]);
                }
            }
            else
            {
                animes.AddRange(anmList);
            }
  


            ViewBag.Animes = animes;
            if (user!=null) 
            { 
                var x = _context.UsersAnime.FirstOrDefault(f => f.AnimeID == id && f.UserID == user.Id);
                ViewBag.checklike = x;
                ViewBag.checkPremium = user.isPermium;
                if(user.PremiumExpiration<DateTime.Now)
                {
                    user.isPermium = false;
                    await userManager.UpdateAsync(user);
                }
            }
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        [Authorize(Roles = "Client")]
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

                var list = _context.UsersAnime.ToList();
                decimal totalrating = 0;
                int numofusers = 0;
                for (int i = 0; i < list.Count; i++)
                {

                    if (list[i].Rating != 0)
                    {
                        totalrating += list[i].Rating;
                        numofusers++;
                    }
                }

                if (numofusers == 0) {
                    totalrating = 0;
                }
                else {
                totalrating = totalrating / numofusers;

                }
                var anime = _context.Anime.AsNoTracking().FirstOrDefault(oo => oo.ID == id);
                if (anime != null)
                {
                    anime.Rating = totalrating;
                    _context.Anime.Update(anime);
                    _context.SaveChanges();
                }

            }
            return Redirect("Details/" + id);
        }
        [Authorize(Roles = "Client")]
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
                    return Redirect($"Details/{id}");

                }
            }
            return Redirect("/identity/account/login");
        }
        [Authorize(Roles = "Client")]
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

                    var list = _context.UsersAnime.ToList();
                    decimal totalrating=0;
                    int numofusers = 0;
                    for (int i =0; i< list.Count; i++) {

                        if (list[i].Rating != 0)
                        {
                            totalrating += list[i].Rating;
                            numofusers++;
                        }
                    }
                    
                    totalrating = totalrating / numofusers;
                    var anime =  _context.Anime.AsNoTracking().FirstOrDefault(oo=>oo.ID==id);
                    if (anime != null)
                    {
                        anime.Rating = totalrating;
                        _context.Anime.Update(anime);
                        _context.SaveChanges();
                    }

                }
            }
            return Redirect($"Details/{id}");
        }
        [Authorize(Roles = "Client")]
        [HttpGet]
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
