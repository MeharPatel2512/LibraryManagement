using Library.Exceptions.CustomExceptions;
using Library.Utility.Config;

namespace Library.Exceptions
{
    public class GlobalExceptionMiddleware
    {
        readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case DatabaseException:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                    case BadRequestException:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case NoContentException:
                        response.StatusCode = StatusCodes.Status204NoContent;
                        break;
                    case UnauthorizedException:
                        response.StatusCode = StatusCodes.Status401Unauthorized;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                if (error is Microsoft.Data.SqlClient.SqlException && ((Microsoft.Data.SqlClient.SqlException)error).Class == 16)
                {
                    response.StatusCode = StatusCodes.Status202Accepted;
                }

                ErrorInfo info = new ErrorInfo
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = error.Message ?? "An unknown Error Occurred!",
                    RequestPath = $"{context.Request.Method} {context.Request.Scheme}://{context.Request.Host.Value}{context.Request.Path}"
                };

                await response.WriteAsync(info.ToJson());
                _logger.LogError(error.Message ?? "An unknown Error Occurred", error);

            }
        }
    }
}
