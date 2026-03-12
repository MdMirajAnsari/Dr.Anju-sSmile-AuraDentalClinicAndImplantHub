using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var errorResponse = new { Message = "An unexpected error occurred.", Details = ex.Message };
                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }

        public Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var errorResponse = new { Message = "An unexpected error occurred.", Details = ex.Message };

            switch (ex)
            {
                case KeyNotFoundException:
                    context.Response.StatusCode = 404;
                    errorResponse = new { Message = "Resource not found.", Details = ex.Message };
                    break;

                case UnauthorizedAccessException:
                    context.Response.StatusCode = 401;
                    errorResponse = new { Message = "Unauthorized access.", Details = ex.Message };
                    break;

                case ArgumentException:
                    context.Response.StatusCode = 400;
                    errorResponse = new { Message = "Bad request.", Details = ex.Message };
                    break;

                case InvalidOperationException:
                    context.Response.StatusCode = 409;
                    errorResponse = new { Message = "Conflict occurred.", Details = ex.Message };
                    break;

                case TimeoutException:
                    context.Response.StatusCode = 504;
                    errorResponse = new { Message = "Request timed out.", Details = ex.Message };
                    break;

                case NotImplementedException:
                    context.Response.StatusCode = 501;
                    errorResponse = new { Message = "Not implemented.", Details = ex.Message };
                    break;

            }
            context.Response.WriteAsJsonAsync(errorResponse);
            return context.Response.WriteAsJsonAsync(errorResponse);
        }

        
    }
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
