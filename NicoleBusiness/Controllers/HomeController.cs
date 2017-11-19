using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NicoleBusiness.Models;

namespace NicoleBusiness.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Income()
        {
            ViewData["Message"] = "Your application description page.";

            return View("/Views/Income/Income.cshtml");
        }
        
        public IActionResult Expense()
        {
            ViewData["Message"] = "Your application description page.";

            return View("/Views/Expense/Expense.cshtml");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
