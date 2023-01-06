using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Njs.Core.Exceptions;
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

            await WriteResponseAsync(HttpStatusCode.BadRequest, "One ore more validation exceptions occured", response);
        }
        catch (NjsException gyroException)
        {
            await WriteResponseAsync(HttpStatusCode.BadRequest, gyroException.Message, gyroException.Errors);
        }
        catch (Exception ex)
        {
            await WriteResponseAsync(
                HttpStatusCode.InternalServerError,
                "An unknown error occured",
                ImmutableDictionary<string, IEnumerable<string>>.Empty);
        }

        async Task WriteResponseAsync(HttpStatusCode statusCode, string title, IDictionary<string, IEnumerable<string>> errors)
        {
            context.Response.StatusCode = (int)statusCode;

            var content = new
            {
                title,
                errors
            };
            
            await context.Response.WriteAsJsonAsync(content);
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