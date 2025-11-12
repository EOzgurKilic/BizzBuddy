using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        
        // Hata türüne göre HTTP durum kodunu belirle
        var statusCode = StatusCodes.Status500InternalServerError;
        var message = "Internal Server Error.";
        var errors = new Dictionary<string, string[]>();

        if (exception is ValidationException validationException)
        {
            statusCode = StatusCodes.Status400BadRequest;
            message = "Validation Failed.";
            
            // FluentValidation hatalarını gruplayıp daha temiz bir formata dönüştür
            errors = validationException.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(x => x.ErrorMessage).ToArray()
                );
        }
        
        context.Response.StatusCode = statusCode;

        // Yanıt gövdesini oluştur
        var result = JsonSerializer.Serialize(new 
        { 
            statusCode, 
            message, 
            errors 
        });

        return context.Response.WriteAsync(result);
    }
}