using System.Diagnostics;
using System.Text.Json;

namespace TaxCalculatorAPI.Middlewares
{
    internal sealed class BadRequestExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<BadRequestExceptionHandlingMiddleware> _logger;

        public BadRequestExceptionHandlingMiddleware(ILogger<BadRequestExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exceptions.BadRequestException e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exceptions.BadRequestException exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {
                title = GetTitle(exception),
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                status = statusCode,
                detail = exception.Message,
                traceId = Activity.Current?.Id ?? "",
                errors = GetErrors(exception)
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exceptions.BadRequestException exception) =>
            exception switch
            {
                Exceptions.BadRequestException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status400BadRequest
            };

        private static string GetTitle(Exceptions.BadRequestException exception)
        {
            return "Bad Request!";
        }

        private static IDictionary<string, string[]> GetErrors(Exceptions.BadRequestException exception)
        {
            IDictionary<string, string[]> errors = null;

            if (exception is Exceptions.BadRequestException badRequestException)
            {
                errors = badRequestException.Errors;
            }

            return errors;
        }
    }
}
