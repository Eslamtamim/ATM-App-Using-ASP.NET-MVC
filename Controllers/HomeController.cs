using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcTest1.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;


namespace mvcTest1.Controllers
{
    public class HomeController : Controller
    {
        AccountDbContext context = new AccountDbContext();



        public IActionResult AllAccounts()
        {
            List<Account> accounts = context.Accounts.OrderBy(m => m.FirstName).ToList();
            int count = 0;
            ViewBag.message = count;
            return View(accounts);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
   
        public IActionResult Accountinfo(string id)
        {
          var  info = context.Accounts.FirstOrDefault(m => m.Id == id);

            //var account = context.Accounts.FirstOrDefault(e => e.Id == loginId);

                return View(info);
           

        }

        //////////////////////////////////////////////////////////////

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(Account a)
        {
            if (ModelState.IsValid)
            {
                context.Accounts.Add(a);
                context.SaveChanges();

                return View("AllAccounts");
            }
            return View();
        }

        

    }
}