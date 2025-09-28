using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // url: http://localhost:5049/bookstore/false/1?isloggedin=true&bookid=10

        [Route("bookstore/{isloggedin?}/{bookid?}")]
        public IActionResult Index(int? bookid, [FromRoute]bool? isloggedin, Book book)
        {
            // Book Id should be supplied & can't be empty
            if (bookid.HasValue == false)
            {
                return BadRequest("Book id is not supplied or empty"); // Response.StatusCode = 400;
            }

            // Book id should be between 1 to 1000
            if (bookid <= 0)
            {
                return BadRequest("Book Id can't be less than or equal to zero");
            }

            if (bookid > 1000)
            {
                return NotFound("Book Id can't be greater than 1000"); // Response.StatusCode = 404;
            }

            // isloggedin should be true
            if (isloggedin == false)
            {
                return Unauthorized("User must be authenticated"); // Response.StatusCode = 401;
            }

            return Content($"Book id: {bookid}, Book: {book}", "text/plain");
        }
    }
}
