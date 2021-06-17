using Mensahero.Data;
using Mensahero.Models;
using Mensahero.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mensahero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext database;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            database = db;
        }

        //READ
        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                Messages = database.Message.ToList(),
                Message = new Message()
            };

            homeVM.Messages = homeVM.Messages.Select(x => { x.Text = Encryption.Message.Decrypt(x.Text); return x; }).ToList();
            return View(homeVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(Message message)
        {
            var msg = Encryption.Message.Crypt(message.Text);
            message.Text = msg;
            message.FromUserId = "from user id test";
            message.ToUserId = "to user id test";
            message.TimeStamp = DateTime.Today;
            database.Add(message);
            database.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        //EDIT
        public IActionResult Edit(Message message)
        {
            var msg = database.Message.Find(message.Id);
            msg.Text = Encryption.Message.Crypt(message.Text);
            if (ModelState.IsValid)
            {
                database.Message.Update(msg);
                database.SaveChanges();
            }

            HomeVM homeVM = new()
            {
                Messages = database.Message.ToList(),
                Message = message
            };
            return RedirectToAction("Index", homeVM);

        }


        //DELETE
        [HttpPost]
        public IActionResult Delete(Message message)
        {
            var msg = database.Message.Find(message.Id);
            if (ModelState.IsValid)
            {
                database.Message.Remove(msg);
                database.SaveChanges();
            }

            HomeVM homeVM = new()
            {
                Messages = database.Message.ToList(),
                Message = msg
            };
            return RedirectToAction("Index", homeVM);

        }
    }
}
