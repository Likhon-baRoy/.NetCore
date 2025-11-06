using RazorView.Models;
using RazorView.Services;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
// Add custom service
builder.Services.AddScoped<FinnhubService>();

// Bind appsettings sections to options classes
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("weatherAPI"));

builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));

// builder.Services.AddTransient<ICitiesService, CitiesService>();
builder.Services.AddScoped<ICitiesService, CitiesService>();
// builder.Services.AddSingleton<ICitiesService, CitiesService>();

// add services into IoC container
builder.Services.AddSingleton<ICountriesService, CountriesService>();
builder.Services.AddSingleton<IPersonsService, PersonsService>();

// Optional config file: load MyOwnConfig.json
builder.Configuration.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsEnvironment("test1") || app.Environment.IsEnvironment("test2"))
{
  app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.MapControllers();

app.Run();
