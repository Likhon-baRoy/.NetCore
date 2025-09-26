var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
  WebRootPath = "myroot"
});
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.MapFallback(async context =>
{
  await context.Response.WriteAsync($"No route matched at - {context.Request.Path}");
});

app.Run();