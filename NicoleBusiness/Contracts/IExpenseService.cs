using NicoleBusiness.Models;

namespace NicoleBusiness.Contracts
{
    public interface IExpenseService
    {
        string CreateExpense(Expense expense);
    }
}