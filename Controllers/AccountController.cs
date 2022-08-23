using Microsoft.AspNetCore.Mvc;
using mvcTest1.Models;
using System.Security.Principal;

namespace mvcTest1.Controllers
{
	public class AccountController : Controller
	{

        AccountDbContext context = new AccountDbContext();



        [HttpGet]
        public IActionResult Edit(string id)
        {
            var account = context.Accounts.FirstOrDefault(context => context.Id == id);

            return View(account);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Account a)
        {
            if (ModelState.IsValid)
            {
                context.Accounts.Update(a);
                context.SaveChanges();

                return RedirectToAction("AllAccounts", "Home");
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {

            var account = context.Accounts.FirstOrDefault(context => context.Id == id);

            context.Accounts.Remove(account);
                context.SaveChanges();

                return RedirectToAction("AllAccounts", "Home");
           
          
        }

        [HttpGet]
        public IActionResult Withdraw(string? id)
        {
            var account = context.Accounts.FirstOrDefault(context => context.Id == id);
            return View(account);
        }

        [HttpPost]

        public IActionResult Withdraw(string? Id, int? amount)
        {
            var account = context.Accounts.FirstOrDefault(context => context.Id == Id);
            string Amount = Request.Form["Amount"];
            account.Balance -= int.Parse(Amount);
            context.SaveChanges();
            return View(account);
        }

        [HttpGet]
        public IActionResult Deposite(string? id)
        {
            var account = context.Accounts.FirstOrDefault(context => context.Id == id);
            return View(account);
        }

        [HttpPost]

        public IActionResult Deposite(string? Id, int? amount)
        {
            var account = context.Accounts.FirstOrDefault(context => context.Id == Id);
            string Amount = Request.Form["Amount"];
            account.Balance += int.Parse(Amount);
            context.SaveChanges();
            return View(account);
        }



        [HttpGet]
        public IActionResult Transfer(string? id)
        {
            var account = context.Accounts.FirstOrDefault(context => context.Id == id);
            return View(account);
        }

        [HttpPost]

        public IActionResult Transfer(string? Id, int? amount , string user)
        {
            var account = context.Accounts.FirstOrDefault(context => context.Id == Id);
            var Trans = context.Accounts.FirstOrDefault(context => context.Id == user || context.Email == user || context.PhoneNumber == user);

            string Amount = Request.Form["Amount"];
            account.Balance -= int.Parse(Amount);
            Trans.Balance += int.Parse(Amount);
            context.SaveChanges();
            return View(account);
        }

    }
}
