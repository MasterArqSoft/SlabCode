using CodeFirst.Core.Exceptions;
using CodeFirst.Domain.Settings;
using System.Collections.Generic;

namespace CodeFirst.Web.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }

        public ApiResponse(T data)
        {
            Data = data;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<ErrorSetting> Errors { get; set; }
        public T Data { get; set; }
    }
}