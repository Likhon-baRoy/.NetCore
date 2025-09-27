using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // we're expecting url: http://localhost:5049/bookstore?isloggedin=true&bookid=1

        [Route("bookstore")]
        public IActionResult Index()
        {
            // Book Id should be supplied
            if (!Request.Query.ContainsKey("bookid"))
            {
                return BadRequest("Book id is not supplied"); // Response.StatusCode = 400;
            }

            // Book Id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("Book Id can't be null or empty");
            }

            // Book id should be between 1 to 1000
            int bokId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bokId <= 0)
            {
                return BadRequest("Book Id can't be less than or equal to zero");
            }

            if (bokId > 1000)
            {
                return NotFound("Book Id can't be greater than 1000"); // Response.StatusCode = 404;
            }

            // isloggedin should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                return Unauthorized("User must be authenticated"); // Response.StatusCode = 401;
            }

            // return RedirectToAction("Books", "Store", new { }); // 302 - Found
            return RedirectToActionPermanent("Books", "Store", new { }); // 301 - Moved Permanently
        }
    }
}
