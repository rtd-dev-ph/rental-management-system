using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using RMS.Shared.Exceptions;

namespace RMS.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        object response;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                response = new
                {
                    title = "Validation Error",
                    status = (int)statusCode,
                    detail = validationException.Message
                };
                _logger.LogWarning("Validation error: {Message}", validationException.Message);
                break;
 
            case DbUpdateException { InnerException: PostgresException { SqlState: "23505" } pgEx }:
                    statusCode = HttpStatusCode.Conflict;
                    
                    // Extract column name from PostgreSQL error
                    var detail = pgEx.Detail ?? "A duplicate value was detected";
                    
                    response = new
                    {
                        title = "Duplicate Entry",
                        status = (int)statusCode,
                        detail = detail
                    };
                    _logger.LogWarning("Duplicate entry: {Detail}", detail);
                    break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                response = new
                {
                    title = "Server Error",
                    status = (int)statusCode,
                    detail = "An unexpected error occurred"
                };
                _logger.LogError(exception, "Unhandled exception");
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
    }
}
