using CodeFirst.Core.Exceptions;
using CodeFirst.Core.Responses;
using CodeFirst.Web.Api.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Middlewares
{
    public class GlobalErrorException
    {
        private readonly RequestDelegate _next;

        public GlobalErrorException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case ApiException:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case ValidationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        responseModel.Errors = e.Errors;
                        break;

                    case KeyNotFoundException:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result).ConfigureAwait(false);
            }
        }
    }
}