using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // we're expecting url: http://localhost:5049/book?isloggedin=true&bookid=1

        [Route("book")]
        public IActionResult Index()
        {
            // Book Id should be supplied
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied");
            }

            // Book Id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("Book Id can't be null or empty");
            }

            // Book id should be between 1 to 1000
            int bokId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);

            if (bokId < 1)
            {
                Response.StatusCode = 400;
                return Content("Booking Id can't be less than or equal to zero");
            }

            if (bokId > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book Id can't be greater than 1000");
            }

            // isloggedin should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                Response.StatusCode = 401;
                return Content("User must be authenticated");
            }

            return File("/sample.pdf", "application/pdf");
        }
    }
}
