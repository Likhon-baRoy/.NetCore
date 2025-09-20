using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
  Console.WriteLine($"\nMethod:\t\t {context.Request.Method}\nPath:\t\t{context.Request.Path}\nStatusCode:\t\t{context.Response.StatusCode}\n");

  var endpoint = context.GetEndpoint();

  if (endpoint != null)
  {
    Console.WriteLine($"Matched endpoint: {endpoint.DisplayName}");
  }
  else
  {
    Console.WriteLine("No endpoint matched");
  }

  await next();
});

app.UseRewriter(new RewriteOptions().AddRedirect("history", "about"));

app.MapGet("/", () => "Hello World!");
app.MapGet("/about", () => "Contos was founded in 2000.");
app.MapGet("/files/{filename}.{extension}", async (HttpContext context) =>
{
  string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
  string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
  await context.Response.WriteAsync($"This in files: {filename} - {extension}");
});

app.Run();