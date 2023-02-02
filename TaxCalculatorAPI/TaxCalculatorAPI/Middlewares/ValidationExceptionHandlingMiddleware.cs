using System.Diagnostics;
using System.Text.Json;
using TaxCalculatorAPI.Exceptions;

namespace TaxCalculatorAPI.Middlewares
{
    public sealed class ValidationExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ValidationExceptionHandlingMiddleware> _logger;

        public ValidationExceptionHandlingMiddleware(ILogger<ValidationExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException e)
            {
                _logger.LogError(e, e.Message);
                await HandleValidationExceptionAsync(context, e);
            }
        }

        private static async Task HandleValidationExceptionAsync(HttpContext httpContext, ValidationException exception)
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

        private static int GetValidationExceptionStatusCode(ValidationException exception) =>
            exception switch
            {
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status400BadRequest
            };

        private static string GetValidationExceptionTitle(ValidationException exception)
        {
            return "Validation Fails!";
        }

        private static IDictionary<string, string[]> GetValidationExceptionErrors(ValidationException exception)
        {
            IDictionary<string, string[]> errors = null;

            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
