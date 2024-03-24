using System.Text.Json;

namespace ZAMY.Api.Middlewares
{
    public class GlobalExeptionHandlingMiddleware(ILogger<GlobalExeptionHandlingMiddleware> _logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            }
            catch (Exception e)
            {

                _logger.LogError(e, e.Message);

                ApiResponse problemDetails = new()
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessage = { "Internal Server Error" }
                };

                string json = JsonSerializer.Serialize(problemDetails);

                await context.Response.WriteAsync(json);

                context.Response.ContentType = "application/json";


            }
        }
    }
}
