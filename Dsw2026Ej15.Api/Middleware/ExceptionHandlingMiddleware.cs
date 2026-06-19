using Dsw2026Ej15.Domain.Exceptions;
using System.Text.Json;

namespace Dsw2026Ej15.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";

            var body = JsonSerializer.Serialize(new { message = ex.Message });
            await context.Response.WriteAsync(body);
        }
        catch (Exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";

            var body = JsonSerializer.Serialize(new
            {
                title = "Internal Server Error",
                status = 500,
                message = "Ocurrió un error interno en el servidor."
            });
            await context.Response.WriteAsync(body);
        }
    }
} }
}
