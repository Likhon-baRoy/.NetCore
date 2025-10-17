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
            ViewBag.MyKey = _configuration["mykey"];
            ViewBag.MyAPIKey = _configuration.GetValue("MyAPIKey", "The default key");
            return View();
        }

    }
}
