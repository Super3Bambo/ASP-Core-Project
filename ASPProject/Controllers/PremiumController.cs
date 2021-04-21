using ASPProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPProject.Controllers
{
    [Authorize]
    public class PremiumController : Controller
    {
        private readonly IHttpContextAccessor Accessor;
        private readonly UserManager<ApplicationUser> User;
        public string ID;
        public PremiumController(IHttpContextAccessor accessor, UserManager<ApplicationUser> myUser)
        {
            this.Accessor = accessor;
            this.User = myUser;
            this.ID = Accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).ToString().Split(" ")[1];
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Charge(string stripeEmail, string stripeToken)
        {
            var CurUser = await User.FindByIdAsync(ID);
            var customers = new CustomerService();
            var charges = new ChargeService();
            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken,
                Name = CurUser.Firstname+" "+CurUser.Lastname,
                Address = new AddressOptions
                {
                    City = CurUser.City,
                    State = CurUser.State,
                    Country = CurUser.Country,
                    PostalCode = "11511",
                    Line1 = "Line1",
                    Line2 = "Line2"
                },
            });
            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 30000,
                Description = "Premium payment",
                Currency = "EGP",
                Customer = customer.Id,
                ReceiptEmail = stripeEmail,
            });
            if (charge.Status == "succeeded")
            {
                CurUser.PremiumTransactionID = charge.BalanceTransactionId;
                CurUser.isPermium = true;
                CurUser.PremiumExpiration = DateTime.Now.AddDays(30);
                await User.UpdateAsync(CurUser);
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
    }
}
