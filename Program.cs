using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
  WebRootPath = "myroot"
});
var app = builder.Build();

app.UseStaticFiles(); // works with the web root path (myroot)
app.UseStaticFiles(new StaticFileOptions()
{
  FileProvider = new PhysicalFileProvider(
    Path.Combine(builder.Environment.ContentRootPath, "mywebroot")
  )
}); // works with "mywebroot"

app.MapGet("/", () => "Hello World!");

app.MapFallback(async context =>
{
  await context.Response.WriteAsync($"No route matched at - {context.Request.Path}");
});

app.Run();