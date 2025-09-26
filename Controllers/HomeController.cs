using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        [Route("sayhello")] // one url for method1()
        [Route("/")] // another url for method1()
        public string method1()
        {
            return "Hello from Controller method1()\n";
        }
        // public ActionResult Index()
        // {
        //     return View();
        // }

    }
}
