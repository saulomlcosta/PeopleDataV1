using Newtonsoft.Json;
using PeopleDataV1.ViewModels;

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
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = StatusCodes.Status500InternalServerError;
        var message = "Internal Server Error";
        var details = exception.Message;

        var response = new ResultViewModel<ExceptionHandlingMiddleware>($"{statusCode:D} - {message}: {details}");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}
