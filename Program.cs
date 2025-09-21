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
app.MapGet("/employee/profile/{EmployeeName=Likhon}", async context => // Parameter does not matter in name convention
{
  string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
  await context.Response.WriteAsync($"In Employee profile, Emploee Name: {employeeName}");
});
app.MapGet("products/details/{id?}", async context =>
{
  if (context.Request.RouteValues.ContainsKey("id"))
  {
    int id = Convert.ToInt32(context.Request.RouteValues["id"]);
    await context.Response.WriteAsync($"Products details - {id}");
  }
  else
  {
    await context.Response.WriteAsync($"Products details - /id is not supplied");
  }
});

app.Run();