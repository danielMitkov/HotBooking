using HotBooking.Core.Exceptions;
using System.Net;

namespace Microsoft.AspNetCore.Builder;

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
        catch (InternalServerException ex)
        {
            await HandleInternalServerErrorAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleGeneralErrorAsync(context, ex);
        }
    }

    private async Task HandleInternalServerErrorAsync(HttpContext context, InternalServerException ex)
    {
        _logger.LogError(ex, "Internal Server Error");
        context.Response.Redirect("/Home/Error?statusCode=500&message=" + WebUtility.UrlEncode(ex.Message));
        await context.Response.CompleteAsync();
    }

    private async Task HandleGeneralErrorAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, "General Error");
        context.Response.Redirect("/Home/Error?statusCode=400&message=" + WebUtility.UrlEncode(ex.Message));
        await context.Response.CompleteAsync();
    }
}