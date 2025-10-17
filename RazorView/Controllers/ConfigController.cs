using Microsoft.AspNetCore.Mvc;
using RazorView.Models;

namespace RazorView.Controllers
{
    public class ConfigController : Controller
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("config")]
        public ActionResult Index()
        {
            // using options object to get specific keys
            // Options: Loads configuration values into a new Options object
            WeatherApiOptions options = _configuration.GetSection("weatherAPI").Get<WeatherApiOptions>();

            // Bind: Loads configuration values into a new Options object
            // WeatherApiOptions options = new WeatherApiOptions();
            // _configuration.GetSection("weatherAPI").Bind(options);

            ViewBag.ClientID = options.ClientID;
            ViewBag.ClientSecret = options.ClientSecret;

            return View();
        }

    }
}
