using Microsoft.AspNetCore.Mvc;
using NicoleBusiness.Contracts;
using NicoleBusiness.Models;

namespace NicoleBusiness.Controllers
{
    public class TransactionTypeController : Controller
    {
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeController(ITransactionTypeService transactionTypeService)
        {
            _transactionTypeService = transactionTypeService;
        }

        public IActionResult CreateTransactionType(TransactionType transactionType)
        {
            var result = _transactionTypeService.CreateTransactionType(transactionType);
            return result.Success ? Ok(result) : StatusCode(500, result);
        }

        public IActionResult DeleteTransactionType(string transactionTypeName)
        {
            var result = _transactionTypeService.DeleteTransactionType(transactionTypeName);
            return result.Success ? Ok(result) : StatusCode(500, result);
        }

        public IActionResult GetTransactionType()
        {
            var result = _transactionTypeService.GetTransactionType();
            return result.Success ? Ok(result) : StatusCode(500, result);
        }
    }
}