using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RazorView.Models;

namespace RazorView.Controllers
{
    public class ConfigController : Controller
    {
        private readonly WeatherApiOptions _options;

        public ConfigController(IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _options = weatherApiOptions.Value;
        }

        [Route("config")]
        public ActionResult Index()
        {
            ViewBag.ClientID = _options.ClientID;
            ViewBag.ClientSecret = _options.ClientSecret;

            return View();
        }

    }
}
