using Microsoft.AspNetCore.Mvc;
using NicoleBusiness.Contracts;
using NicoleBusiness.Models;

namespace NicoleBusiness.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public IActionResult EnterExpense(Expense model)
        {
            _expenseService.CreateExpense(model);
            return View("/Views/Expense/Expense.cshtml");
        }
    }
}