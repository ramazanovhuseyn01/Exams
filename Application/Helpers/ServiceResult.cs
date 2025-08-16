using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class ServiceResult
    {
        public bool Success { get; }

        public bool Fail => !Success;

        public string? Message { get; set; }

        public string[]? Errors { get; set; }

        public ServiceResult(bool status, string? message)
        {
            Success = status;
            Message = message;
        }

        public ServiceResult()
        {
        }

        public ServiceResult(bool status, string? message, string[]? errors)
        {
            Success = status;
            Message = message;
            Errors = errors;
        }

        public static ServiceResult Failed(string? message = null, string[]? errors = null)
        {
            return new ServiceResult(status: false, message, errors);
        }

        public static ServiceResult Succeed(string? message = null)
        {
            return new ServiceResult(status: true, message);
        }
    }
}
