using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using NicoleBusiness.Contracts;
using NicoleBusiness.Models;

namespace NicoleBusiness.Services
{
    public class ExpenseService : IExpenseService
    {
        private NicoleBusinessDbContext _dbContext { get; }

        public ExpenseService(NicoleBusinessDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public string CreateExpense(Expense expense)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var e = new Expense
                    {
                        Amount = expense.Amount,
                        Description = expense.Description,
                        TaxWriteOff = true,
                        TransactionDate = expense.TransactionDate,
                        TransactionTypeId = expense.TransactionTypeId
                    };

                    _dbContext.Expense.Add(e);
                    _dbContext.SaveChanges();
                    
                    transaction.Commit();
                }
                return "Worked";
            }
            catch (Exception e)
            {
                return "Failed";
            }
        }
    }
}