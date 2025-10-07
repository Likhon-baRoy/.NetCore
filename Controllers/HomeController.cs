using Microsoft.AspNetCore.Mvc;
using RazorView.Models;

namespace RazorView.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("home")]
        public ActionResult Index()
        {
            ViewData["appTitle"] = "Asp.Net Core App";
            List<Person> people = new List<Person>()
            {
                new Person()
                {
                    Name = "John",
                    DateOfBirth = DateTime.Parse("2000-05-06"),
                    PersonGender = Gender.Male
                },
                new Person()
                {
                    Name = "Linda",
                    DateOfBirth = DateTime.Parse("2000-01-09"),
                    PersonGender = Gender.Female
                },
                new Person()
                {
                    Name = "Susan",
                    DateOfBirth = DateTime.Parse("2000-07-12"),
                    PersonGender = Gender.Other
                }
            };

            ViewData["people"] = people;

            return View();
        }

    }
}
