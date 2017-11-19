using Microsoft.AspNetCore.Mvc;
using NicoleBusiness.Models;
using NicoleBusiness.Contracts;

namespace NicoleBusiness.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        
        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        public IActionResult EnterIncome(Income model)
        {
            ViewData["Message"] = "Your application description page.";
            _incomeService.Add(model);
            return View("/Views/Income/Income.cshtml");
        }
    }
}
