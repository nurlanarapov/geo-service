using System.Net;
using System.Security.Authentication;
using System.Text.Json;

namespace geo_service.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment environment)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex?.InnerException?.Message ?? ex.Message);
                await HandleExceptionAsync(context, ex, environment);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, IWebHostEnvironment environment)
        {
            var response = context.Response;

            if (ex is ApiException e)
                response.StatusCode = (int)e.StatusCode;
            else
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var body = new ApiException(ex.Message, (HttpStatusCode)response.StatusCode);

            var result = JsonSerializer.Serialize(body);
            await response.WriteAsync(result);
        }
    }
}