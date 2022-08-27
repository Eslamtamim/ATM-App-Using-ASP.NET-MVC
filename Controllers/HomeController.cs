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


       
        public IActionResult AllAccounts(string SortField, string CurrentSortField, sorting sortDir)
        {

          //  List<Account> accounts = context.Accounts.OrderBy(m => m.FirstName).ToList();
            var accounts = data();
            int count = 0;
            ViewBag.message = count;
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
            //List<string> Governments = new List<string>() { "Alexandria", "Aswan", "Asyut", "Beheira", "Beni Suef", "Cairo", "Dakahlia", "Damietta", "Faiyum", "Gharbia", "Giza", "Ismailia", "Kafr El Sheikh", "Luxor", "Matruh", "Minya", "Monufia", "New Valley", "North Sinai", "Port Said[5]", "Qalyubia", "Qena", "Red Sea", "Sharqia", "Sohag", "South Sinai", "Suez" };
           // ViewBag.Government = Governments;

            //ViewBag.PinError = true;

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(Account a)
        {
            //if (Request.Form["Pin"] == Request.Form["Pincon"])
            //{

            //    if (ModelState.IsValid)
            //    {
            //        context.Accounts.Add(a);
            //        context.SaveChanges();

            //        return View("AllAccounts");
            //    }
            //    return View();

            //}
            //else
            //{

            //    ViewBag.PinError = false;
            //    List<string> Governments = new List<string>() { "Alexandria", "Aswan", "Asyut", "Beheira", "Beni Suef", "Cairo", "Dakahlia", "Damietta", "Faiyum", "Gharbia", "Giza", "Ismailia", "Kafr El Sheikh", "Luxor", "Matruh", "Minya", "Monufia", "New Valley", "North Sinai", "Port Said[5]", "Qalyubia", "Qena", "Red Sea", "Sharqia", "Sohag", "South Sinai", "Suez" };
            //    ViewBag.Government = Governments;

            //    return View("Signup", a);
            //}

            if (ModelState.IsValid)
            {
                context.Accounts.Add(a);
                context.SaveChanges();
                return RedirectToAction("AllAccounts");
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