using Microsoft.AspNetCore.Mvc;

namespace RazorView.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        public ActionResult Index()
        {
            return View(); // Views/Home/Index.cshtml
            // return View("abc"); // Views/Home/abc.cshtml
        }

    }
}
