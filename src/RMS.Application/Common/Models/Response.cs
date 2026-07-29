using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Application.Common.Models
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public string? ErrorCode { get; set; } // Optional: for more detailed error handling

        // Success factory method
        public static Response<T> Success(T data, string? message = null)
        {
            return new Response<T>
            {
                IsSuccess = true,
                Data = data,
                Message = message ?? "Operation completed successfully"
            };
        }

        // Failure factory method
        public static Response<T> Failure(string message, string? errorCode = null)
        {
            return new Response<T>
            {
                IsSuccess = false,
                Message = message,
                ErrorCode = errorCode
            };
        }
    }

    // Optional: For endpoints that don't return data (e.g., DELETE, PUT)
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? ErrorCode { get; set; }

        public static Response Success(string? message = null)
        {
            return new Response
            {
                IsSuccess = true,
                Message = message ?? "Operation completed successfully"
            };
        }

        public static Response Failure(string message, string? errorCode = null)
        {
            return new Response
            {
                IsSuccess = false,
                Message = message,
                ErrorCode = errorCode
            };
        }
    }
}