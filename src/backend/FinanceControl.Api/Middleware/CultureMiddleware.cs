using System.Globalization;

namespace FinanceControl.Api.Middleware;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;
    
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;        
    }
    
    public async Task Invoke(HttpContext context)
    {
        var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
        
        var requestedCulture = context.Request.Headers["Accept-Language"].FirstOrDefault();

        var cultureInfo = new CultureInfo("en-US");

        if (string.IsNullOrWhiteSpace(requestedCulture) == false && supportedCultures.Any(c => c.Name == requestedCulture))
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }
        
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
        
        await _next(context);
    }
}