using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        [Route("home")] // one url for method1()
        [Route("/")] // another url for method1()
        public ContentResult Index()
        {
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")] // only Digit & exactly 10 number
        public string Contact()
        {
            return "Hello from Contact";
        }

        // public ActionResult Index()
        // {
        //     return View();
        // }

    }
}
