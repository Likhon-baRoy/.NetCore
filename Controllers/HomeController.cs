using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorsList = new List<string>();

                foreach (var values in ModelState.Values)
                {
                    foreach (var error in values.Errors)
                    {
                        errorsList.Add(error.ErrorMessage);
                    }
                }
                string errors = string.Join('\n', errorsList);
                return BadRequest(errors);
            }

            return Content($"{person}");
        }
    }
}
