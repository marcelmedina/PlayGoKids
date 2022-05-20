using System.Text.Json;
using FluentValidation;
using FluentValidation.Results;

namespace CQRSMediatrWithFVAndAutoMapperSampleApi.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
        }

        private static string GetTitle(Exception exception)
        {
            return exception switch
            {
                ApplicationException applicationException => applicationException.Message,
                _ => "Server Error"
            };
        }

        private static IEnumerable<ValidationFailure> GetErrors(Exception exception)
        {
            IEnumerable<ValidationFailure> errors = new List<ValidationFailure>();
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors;
            }
            return errors;
        }
    }
}
