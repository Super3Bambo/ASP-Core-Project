using ASPProject.Models;
using ASPProject.Services;
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
        private readonly IMangerServices<AnimeCategory> animeCategoriesService;
        private readonly IMangerServices<Category> categoryService;
        private readonly IMangerServices<Anime> animeService;
        private readonly IMangerServices<UsersAnime> usersAnimeService;
        private readonly UserManager<ApplicationUser> userManager;


        public HomeController(ILogger<HomeController> logger, IMangerServices<AnimeCategory> animeCategoriesService, IMangerServices<Category> categoryService, IMangerServices<Anime> animeService, IMangerServices<UsersAnime> usersAnimeService, UserManager<ApplicationUser> user)
        {
            _logger = logger;
            this.animeCategoriesService = animeCategoriesService;
            this.categoryService = categoryService;
            this.animeService = animeService;
            this.usersAnimeService = usersAnimeService;
            userManager = user;
        }

        public async Task<IActionResult> Index()
        {
            return View(await animeService.GetAll());
        }
        //[Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var user = await userManager.GetUserAsync(User);
            ViewBag.checkPremium = false;
            var anime = await animeService.GetDetails(id);
            var cat = await animeCategoriesService.GetAll();
            var cats = cat.Where(oo => oo.AnimeID == anime.ID);
            List<Category> categories = new List<Category>();
            foreach (var item in cats)
            {
                var x = await categoryService.GetDetails(item.CategoryID);
                categories.Add(x);
            }


            ViewBag.Cats = categories;

            var anmes = await animeService.GetAll();
            var an = anmes.Where(oo => oo.Name.Contains(anime.Name.Substring(0, 1)));

            List<Anime> animes = new List<Anime>();
            var anl = await animeService.GetAll();
            var anmList = anl.Where(oo => oo.ID != anime.ID).ToList();
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
            if (user != null)
            {
                var y = await usersAnimeService.GetAll();
                var x = y.FirstOrDefault(f => f.AnimeID == id && f.UserID == user.Id);
                ViewBag.checklike = x;
                ViewBag.checkPremium = user.isPermium;
                if (user.PremiumExpiration < DateTime.Now)
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

                if (user != null)
                {

                    await usersAnimeService.Delete(id, user.Id);
                }

                var list = await usersAnimeService.GetAll();
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
                //  var anime = _context.Anime.AsNoTracking().FirstOrDefault(oo => oo.ID == id);
                var anime = await animeService.GetDetails(id);

                if (anime != null)
                {
                    anime.Rating = totalrating;
                    await animeService.Update(anime);
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
                    await usersAnimeService.Insert(usersAnime);
                    return Redirect($"Details/{id}");

                }
            }
            return Redirect("/identity/account/login");
        }
        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<IActionResult> RateIT(int id, int Rating,int? WatchingStatus)
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
                    if(WatchingStatus!=null)
                    {
                        usersAnime.WatchingStatus =(WatchingStatus) WatchingStatus;
                    }
                    await usersAnimeService.Update(usersAnime);

                    var list = await usersAnimeService.GetAll();
                    decimal totalrating = 0;
                    int numofusers = 0;
                    for (int i = 0; i < list.Count; i++) {

                        if (list[i].Rating != 0)
                        {
                            totalrating += list[i].Rating;
                            numofusers++;
                        }
                    }

                    if (numofusers == 0)
                    {
                        totalrating = 0;
                    }
                    else
                    {
                        totalrating = totalrating / numofusers;
                    }
                    //var anime =  _context.Anime.AsNoTracking().FirstOrDefault(oo=>oo.ID==id);
                    var anime = await animeService.GetDetails(id);
                    if (anime != null)
                    {
                        anime.Rating = totalrating;
                        await animeService.Update(anime);
                    }

                }
            }
            return Redirect($"Details/{id}");
        }
        [Authorize(Roles = "Client")]
        //[HttpGet]
        public async Task<IActionResult> FilteredAnimes(string searchKey, string Cat)
        {
            var an = await animeService.GetAll();
      
            if (Cat==null && searchKey==null)
            {
                return View(new List<Anime>());

            }else if(Cat == null && searchKey != null)
            {
                var Anime = an.Where(d => d.Name.StartsWith(searchKey)).ToList();
                return View(Anime);
            }
            else if(Cat != null && searchKey == null)
            {
                var CatID = await categoryService.GetDetailsName(Cat.Trim());
                var CatAn = await animeCategoriesService.GetAll();
                var CatAnime = CatAn.Where(oo => oo.CategoryID == CatID.ID).ToList();
                List<Anime> animesInCat = new List<Anime>();
                foreach (var item in CatAnime)
                {
                    var x = await animeService.GetDetails(item.AnimeID);
                    animesInCat.Add(x);
                }
                return View(animesInCat);
            }
            else
            {

                var Anime = an.Where(d => d.Name.StartsWith(searchKey)).ToList();
                var CatID = await categoryService.GetDetailsName(Cat.Trim());
                var CatAn = await animeCategoriesService.GetAll();
                var CatAnime = CatAn.Where(oo => oo.CategoryID == CatID.ID).ToList();
                List<Anime> animesInCat = new List<Anime>();
                foreach (var item in CatAnime)
                {
                    var x = await animeService.GetDetails(item.AnimeID);
                    animesInCat.Add(x);
                }
                var res = Anime.Intersect(animesInCat).ToList();
                return View(res);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
