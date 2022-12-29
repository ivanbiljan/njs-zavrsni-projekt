using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Njs.Middlewares;

public class ErrorLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadHttpRequestException gyroException)
        {
            await WriteResponseAsync(HttpStatusCode.BadRequest, gyroException.Message);
        }
        catch (Exception ex)
        {
            await WriteResponseAsync(HttpStatusCode.InternalServerError, ex.Message);
        }

        async Task WriteResponseAsync(HttpStatusCode statusCode, object value)
        {
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(value);
        }
    }
}

internal static class ErrorLoggingMiddlewareExtensions
{
    public static void UseResponseRewriter(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseMiddleware<ErrorLoggingMiddleware>();
    }
}