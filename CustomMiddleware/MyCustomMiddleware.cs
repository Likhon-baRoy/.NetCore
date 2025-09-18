namespace WebApp.CustomMiddleware;

public class MyCustomMiddleware : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    await context.Response.WriteAsync("Hello from Custom Middleware! - START\n");
    await next(context);
    await context.Response.WriteAsync("Hello from Custom Middleware! - END\n");
  }
}

public static class CustomMiddlewareExtension
{
  public static IApplicationBuilder UseMyCustomMiddleware (this IApplicationBuilder app)
  {
    return app.UseMiddleware<MyCustomMiddleware>();
  }
}
