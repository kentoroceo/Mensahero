using Mensahero.Data;
using Mensahero.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mensahero.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext database;

        public AccountController(ApplicationDbContext db)
        {
            database = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            User user = database.Users.Where(x => x.Username == username && x.Passowrd == password).FirstOrDefault();

            if (user != null)
            {
                var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, user.Username);
                var claimsIdentity = new ClaimsIdentity(new[] { claimNameIdentifier }, "serverAuth");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
 
                HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
    }
}
