using System;
namespace NicoleBusiness.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool TaxWriteOff { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
