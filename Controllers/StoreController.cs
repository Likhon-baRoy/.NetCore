using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books")]
        public ActionResult Books()
        {
            return Content("<h1>Book Store</h1>", "text/html");
        }

    }
}
