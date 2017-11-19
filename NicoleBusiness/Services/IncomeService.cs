using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NicoleBusiness.Contracts;
using NicoleBusiness.Models;

namespace NicoleBusiness.Services
{
    public class IncomeService : IIncomeService
    {
        private NicoleBusinessDbContext _dbContext { get; }

        public IncomeService(NicoleBusinessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Add(Income income)
        {
            try
            {
                using (var transaction =_dbContext.Database.BeginTransaction())
                {
                    // Creating a new item and saving it to the database
                    var i = new Income
                    {
                        Amount = income.Amount,
                        Description = income.Description,
                        TransactionTypeId = income.TransactionTypeId,
                        TransactionDate = DateTime.Now.ToUniversalTime()
                    };
                    _dbContext.Income.Add(i);
                    
                    var count = _dbContext.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);

                    transaction.Commit();

                    // Retrieving and displaying data
                    Console.WriteLine();
                    Console.WriteLine("All items in the database:");
                    foreach (var item in _dbContext.Income)
                    {
                        Console.WriteLine("{0} | {1}", i.Amount, i.Description);
                    }
                }
                return "Worked";
            }
            catch(Exception e)
            {
                return "Failed";
            }
        }
    }
}