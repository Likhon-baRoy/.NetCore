using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public ActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h1>Book Store {id}</h1>", "text/html");
        }

    }
}
