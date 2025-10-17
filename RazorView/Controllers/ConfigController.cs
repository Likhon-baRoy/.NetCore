using Microsoft.AspNetCore.Mvc;

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
            // Indipendent statement
            ViewBag.ClientID = _configuration["weatherAPI:ClientID"];
            ViewBag.ClientSecret = _configuration.GetValue("weatherAPI:ClientSecret", "The default client secret");

            // using GetSection() method
            IConfigurationSection wetherapiSection = _configuration.GetSection("weatherAPI");
            ViewBag.ClientID = wetherapiSection["ClientID"];
            ViewBag.ClientSecret = wetherapiSection["ClientSecret"];

            return View();
        }

    }
}
