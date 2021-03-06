using ASPProject.Models;
using ASPProject.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddScoped<IMangerServices<UsersAnime>, UsersAnimeService>();
            services.AddScoped<IMangerServices<Anime>, AnimeService>();
            services.AddScoped<IMangerServices<Category>, CategoryService>();
            services.AddScoped<IMangerServices<AnimeCategory>, AnimeCategoriesService>();
            services.AddDbContext<Context>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("conn")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            { 
                options.Password.RequireLowercase =false;
                options.Password.RequireUppercase =false;
                options.Password.RequireDigit =false;
            }).AddEntityFrameworkStores<Context>();
            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "489438948862600";
                options.AppSecret = "5023f2cf74446adefef661cc1131cb44";
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Identity/Account/Login");
                options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
            });
            services.AddAuthorization();
            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

            });
        }
    }
}
