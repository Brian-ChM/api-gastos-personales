using System.Net;
using System.Text.Json;

namespace WebApi.Middleware;

public class CustomExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private const string _contentType = "application/json";

    public CustomExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = _contentType;
            var error = new ErrorModel
            {
                Message = ex.Message,
            };

            var errorJson = JsonSerializer.Serialize(error);
            await context.Response.WriteAsync(errorJson);
        }
    }
}
