using System.Globalization;

namespace CashFlow.Api.Middlewares;

/// <summary>
/// Middleware for setting the culture based on the Accept-Language header of the request in the API.
/// </summary>
public class CultureMiddleware
{
    /// <summary>
    /// Represents the next step in the pipeline.
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="CultureMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next step in the pipeline.</param>
    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Invokes the middleware to set the culture based on the Accept-Language header of the request.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task that represents the completion of request processing.</returns>
    public async Task Invoke(HttpContext context)
    {
        var suportedLanguages = CultureInfo
            .GetCultures(CultureTypes.AllCultures)
            .ToList();

        var requestedCulture = context.Request.Headers.AcceptLanguage
            .FirstOrDefault();

        var cultureInfo = new CultureInfo("en");

        if (string.IsNullOrWhiteSpace(requestedCulture) == false && 
            suportedLanguages.Exists(l => l.Name.Equals(requestedCulture)))
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
