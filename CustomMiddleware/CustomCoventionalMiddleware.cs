namespace WebApp.CustomMiddleware;

public class CustomCoventionalMiddleware
{
  private readonly RequestDelegate _next;

  public CustomCoventionalMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task Ivoke(HttpContext httpContext)
  {
    if (httpContext.Request.Query.ContainsKey("firstname") && httpContext.Request.Query.ContainsKey("lastname"))
    {
      string fullName = httpContext.Request.Query["firstname"] + " " + httpContext.Request.Query["lastname"];

      await httpContext.Response.WriteAsync(fullName);
    }
    await _next(httpContext);
  }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class CustomCoventionalMiddlewareExtensions
{
  public static IApplicationBuilder UseCustomConventionalMiddleware(this IApplicationBuilder app)
  {
    return app.UseMiddleware<CustomCoventionalMiddleware>();
  }
}
