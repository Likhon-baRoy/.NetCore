using Microsoft.AspNetCore.Mvc;
using RazorView.Models;
using Services;
using ServiceContracts;

namespace RazorView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3, IServiceScopeFactory serviceScopeFactory)
        {
            _citiesService1 = citiesService1;
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
            _serviceScopeFactory = serviceScopeFactory;
        }

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

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contact-support")]
        public IActionResult Contact()
        {
            List<string> cities = _citiesService1.GetCities();
            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                // Inject CitiesService
                ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();
                // DB work
                ViewBag.InstanceId_CitiesService_InScope = citiesService.ServiceInstanceId;
            } // end of the scope; it calls CitiesService.Dispose()
            return View(cities);
        }
    }
}
