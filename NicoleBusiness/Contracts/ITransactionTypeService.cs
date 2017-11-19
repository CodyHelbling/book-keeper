using NicoleBusiness.Models;

namespace NicoleBusiness.Contracts
{
    public interface ITransactionTypeService
    {
        ApiResult CreateTransactionType(TransactionType transactionType);
        ApiResult DeleteTransactionType(string transactionTypeName);
        ApiResult GetTransactionType();
    }
}