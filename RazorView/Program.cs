using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// builder.Services.AddTransient<ICitiesService, CitiesService>();
builder.Services.AddScoped<ICitiesService, CitiesService>();
// builder.Services.AddSingleton<ICitiesService, CitiesService>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsEnvironment("test1") || app.Environment.IsEnvironment("test2"))
{
  app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.Map("/home2", async context =>
{
  await context.Response.WriteAsync(app.Configuration["mykey"]! + '\n');
  await context.Response.WriteAsync(app.Configuration.GetValue<string>("mykey")! + '\n');
  await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10) + "\n");
});
app.MapControllers();

app.Run();
