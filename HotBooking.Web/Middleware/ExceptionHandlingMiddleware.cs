namespace HotBooking.Web.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleGeneralErrorAsync(context, ex);
        }
    }

    private async Task HandleGeneralErrorAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, string.Empty);
        context.Response.Redirect("/Home/Error?statusCode=500");
        await context.Response.CompleteAsync();
    }
}
