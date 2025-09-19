var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Use(async (context, next) =>
{
  await context.Response.WriteAsync("I'm the First Middleware\n");
  await next(context);
});

app.UseWhen(
  context => context.Request.Query.ContainsKey("username"),
  app =>
  {
    app.Use(async (context, next) =>
    {
      await context.Response.WriteAsync("I'm from UseWhen middleware!\n");
      await next(context);
    });
  }
);

app.Run(async context =>
{
  await context.Response.WriteAsync("Hello from middleware at main chain.");
});

app.Run();