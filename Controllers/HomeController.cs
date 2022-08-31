using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcTest1.Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;


namespace mvcTest1.Controllers
{

    public enum sorting{
        Ascending,
        Descending,
    }
    
    public class HomeController : Controller
    {
        AccountDbContext context = new AccountDbContext();
            
        private List<Account> data()
        {
            List<Account> accounts = context.Accounts.ToList();
            return accounts;
        }


       
        public IActionResult AllAccounts(string SortField, string CurrentSortField, sorting sortDir , string Search)
        {

          //  List<Account> accounts = context.Accounts.OrderBy(m => m.FirstName).ToList();
            var accounts = data();
            ViewBag.Nomatch = false;
            ViewBag.ViewTable = true;
            int count = 0;
            ViewBag.message = count;
            if (accounts.Count > 0)
            {
                ViewBag.ViewTable = false;
            }           
            if (!string.IsNullOrEmpty(Search))
            {
                accounts = accounts.Where(a=> a.FullName.ToLower().Contains(Search.ToLower())).ToList();  
            }
            if(accounts.Count <= 0)
            {
                ViewBag.Nomatch = true;
            }
           
            return View(this.SortingData(accounts, SortField, CurrentSortField, sortDir));
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
   
        public IActionResult Accountinfo(string Id)
        {
          var  info = context.Accounts.FirstOrDefault(m => m.Id == Id);
                return View(info);           
        }

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
                try
                {
                    context.Accounts.Add(a);
                    context.SaveChanges();
                    return RedirectToAction("AllAccounts");
                }
                catch
                {
                    return RedirectToAction("signup");
                }
            }
            return View();
        }
        private List<Account> SortingData(List<Account> accounts, string SortField, string CurrentSortField, sorting sortDir)
        {

            if (string.IsNullOrEmpty(SortField))
            {
                ViewBag.SortField = "FirstName";
                ViewBag.sortDir = sorting.Ascending;
            }
            else
            {
                if (CurrentSortField == SortField)
                {

                    ViewBag.sortDir = sortDir == sorting.Ascending ? sorting.Descending : sorting.Ascending;
                    ViewBag.SortField = SortField;

                }
                else
                {
                    ViewBag.SortField = SortField;
                    ViewBag.sortDir = sortDir;
                }
            }
            var info = typeof(Account).GetProperty(ViewBag.SortField);
            if (ViewBag.sortDir == sorting.Ascending)
            {
                accounts = accounts.OrderBy(m => info.GetValue(m , null)).ToList();
            }
            else
                accounts = accounts.OrderByDescending(m => info.GetValue(m, null)).ToList();
            return accounts;
        }



    }
}