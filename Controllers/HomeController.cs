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
                    DateOfBirth = null,
                    PersonGender = Gender.Other
                }
            };

            // ViewData["people"] = people;
            // ViewBag.people = people;

            return View(people);
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            ViewBag.appTittle = "View Member Personal Details";

            if (name == null)
                return Content("Person name can't be null");

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
                    DateOfBirth = null,
                    PersonGender = Gender.Other
                }
            };

            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();

            return View(matchingPerson);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person()
            {
                Name = "Sara",
                PersonGender = Gender.Female,
                DateOfBirth = Convert.ToDateTime("2004-07-01")
            };

            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Air Conditioner"
            };

            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel()
            {
                PersonData = person,
                ProductData = product
            };

            return View(personAndProductWrapperModel);
        }

    }
}
