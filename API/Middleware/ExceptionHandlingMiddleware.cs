using API.Models;
using BL.Services;
using System.Text.Json;

namespace API.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly LoggerService _loggerService;

        public ExceptionHandlingMiddleware(LoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
                _loggerService.LogError(ex.Message, nameof(ExceptionHandlingMiddleware), nameof(InvokeAsync));
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };

                var json = JsonSerializer.Serialize(errorResponse);
                await context.Response.WriteAsync(json);
			}
        }
    }
}
