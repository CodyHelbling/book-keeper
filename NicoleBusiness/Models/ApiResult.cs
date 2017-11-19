using Microsoft.AspNetCore.Mvc;

namespace NicoleBusiness.Models
{
    public class ApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
        
    }
}