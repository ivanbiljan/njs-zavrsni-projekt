using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Net;
using ValidationException = FluentValidation.ValidationException;

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
        catch (ValidationException validationException)
        {
            var response = validationException.Errors.GroupBy(f => f.PropertyName)
                .ToImmutableDictionary(g => g.Key, g => g.Select(f => f.ErrorMessage));

            await WriteResponseAsync(HttpStatusCode.BadRequest, response);
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