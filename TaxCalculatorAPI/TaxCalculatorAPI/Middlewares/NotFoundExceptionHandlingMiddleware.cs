using System.Diagnostics;
using System.Text.Json;
using TaxCalculatorAPI.Exceptions;

namespace TaxCalculatorAPI.Middlewares
{
    public sealed class NotFoundExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<NotFoundExceptionHandlingMiddleware> _logger;

        public NotFoundExceptionHandlingMiddleware(ILogger<NotFoundExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, e.Message);
                await HandleValidationExceptionAsync(context, e);
            }
        }

        private static async Task HandleValidationExceptionAsync(HttpContext httpContext, NotFoundException exception)
        {
            var statusCode = GetValidationExceptionStatusCode(exception);
            var response = new
            {
                title = GetValidationExceptionTitle(exception),
                status = statusCode,
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                detail = exception.Message,
                traceId = Activity.Current?.Id ?? "",
                errors = GetValidationExceptionErrors(exception)
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetValidationExceptionStatusCode(NotFoundException exception) =>
            exception switch
            {
                NotFoundException => StatusCodes.Status500InternalServerError,
                _ => StatusCodes.Status500InternalServerError
            };

        private static string GetValidationExceptionTitle(NotFoundException exception)
        {
            return "Internal Server Error (500)";
        }

        private static IDictionary<string, string[]> GetValidationExceptionErrors(NotFoundException exception)
        {
            IDictionary<string, string[]> errors = null;

            if (exception is NotFoundException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
