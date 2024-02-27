using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Web_Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (ValueObjectException ex)
        {
            _logger.LogError(
                ex, $"Exception occurred: {ex.Message}");

            var problemDetails = new ProblemDetails();
            problemDetails.Status = StatusCodes.Status400BadRequest;
            problemDetails.Title = ex.GetType().Name;
            problemDetails.Detail = string.Concat(
                $"Message: '{ex.Message}'");

            context.Response.StatusCode =
                StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}