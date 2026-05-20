using kerp.SystemModel;
using Microsoft.AspNetCore.Diagnostics;

namespace kerp.Middleware
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);

            CustomerResponseModel<object> response = new()
            {
                StatusCode = 500,
                title = "Internal server error",  // exception detayları YOX
                AccessToken = null,
                Data = null
            };

            httpContext.Response.StatusCode = StatusCodes.Status200OK;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
