var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
  await context.Response.WriteAsync("This is Home route\n");
});

app.MapGet("/map", async context =>
{
  await context.Response.WriteAsync("This is Map route\n");
});

app.MapGet("/about", async context =>
{
  await context.Response.WriteAsync("This is About route\n");
});

// Fallback when no other route matches
app.MapFallback(async context =>
{
  await context.Response.WriteAsync($"Request recieved at: {context.Request.Path}");
});

app.Run();