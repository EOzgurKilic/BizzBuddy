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
    var statusCode = StatusCodes.Status500InternalServerError;
    var message = exception.Message; // "Internal Server Error" yerine hatayı yaz
    
    // Eğer iç hata varsa onu da yakalayalım
    var detail = exception.InnerException?.Message; 

    // ... diğer kodlar (ValidationException kontrolü vs.) ...

    context.Response.StatusCode = statusCode;

    var result = JsonSerializer.Serialize(new 
    { 
        statusCode, 
        message, 
        detail, // Detayı buraya ekle
        stackTrace = exception.StackTrace // Hangi satırda koptuğunu gösterir
    });

    return context.Response.WriteAsync(result);
}
}