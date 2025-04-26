using Domain.Exceptions;
using Shared.ErrorModels;
using System.Net;

namespace E_Commerce.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleware> _logger;

        public GlobalErrorHandlingMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
                await HandleNotFoundPathAsync(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleNotFoundPathAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound && !httpContext.Response.HasStarted)
            {
                httpContext.Response.ContentType = "application/json";
                var response = new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    ErrorMessages = $"The endpoint {httpContext.Request.Path} was not found."
                };

                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";

            var statusCode = ex switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                //ServiceException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            httpContext.Response.StatusCode = (int)statusCode;

            var response = new ErrorDetails
            {
                StatusCode = (int)statusCode,
                ErrorMessages = ex.Message
            };

            await httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
