using WebApp.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
  await context.Response.WriteAsync("Hi I'm from Middleware 1\n");
  await next(context);
});

// app.UseMiddleware<MyCustomMiddleware>();
// app.UseMyCustomMiddleware();
app.UseCustomConventionalMiddleware();

app.Run(async (HttpContext context) =>
{
  await context.Response.WriteAsync("\nHi I'm the terminator Middleware from app.Run()");
});

app.Run();