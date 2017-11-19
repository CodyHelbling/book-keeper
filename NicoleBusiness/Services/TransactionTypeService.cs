using System;
using System.Linq;
using NicoleBusiness.Models;
using NicoleBusiness.Contracts;

namespace NicoleBusiness.Services
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly NicoleBusinessDbContext _dbContext;

        public TransactionTypeService(NicoleBusinessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApiResult CreateTransactionType(TransactionType transactionType)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var t = new TransactionType
                    {
                        Name = transactionType.Name,
                        Description = transactionType.Description,
                        CreationDate = DateTime.UtcNow
                    };
                    _dbContext.SaveChanges();

                    transaction.Commit();

                    return new ApiResult
                    {
                        Success = true,
                        Object = transactionType
                    };
                }
            }
            catch (Exception e)
            {
                return new ApiResult
                {
                    Success = false,
                    Object = transactionType
                };
            }
        }

        public ApiResult DeleteTransactionType(string transactionTypeName)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var tt = _dbContext.TransactionType.FirstOrDefault(a => a.Name.Equals(transactionTypeName));

                    if (tt != null)
                    {
                        _dbContext.TransactionType.Remove(tt);
                    }
                    else
                    {
                        return new ApiResult
                        {
                            Success = false,
                            Message = "The TransactionType entered doesn't not exist to delete!",
                            Object = transactionTypeName
                        };
                    }

                    return new ApiResult
                    {
                        Success = true,
                        Object = transactionTypeName
                    };
                }
            }
            catch (Exception e)
            {
                return new ApiResult
                {
                    Success = false,
                    Message = "Failed to delete TransactionType!",
                    Object = transactionTypeName
                };
            }
        }

        public ApiResult GetTransactionType()
        {
            try
            {
                return new ApiResult
                {
                    Success = true,
                    Object = _dbContext.TransactionType.ToList()
                };
            }
            catch (Exception e)
            {
                return new ApiResult
                {
                    Success = false,
                    Message = "Unable to retrieve TransactionTypes from database!"
                };
            }  
        }
    }
}