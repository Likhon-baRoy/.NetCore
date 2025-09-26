var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // adds all the Controller classes as services

var app = builder.Build();

app.MapControllers();

app.MapFallback(async context =>
{
  await context.Response.WriteAsync($"No route matched at - {context.Request.Path}");
});

app.Run();