using System;
namespace NicoleBusiness.Models
{
    public class Income
    {
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
