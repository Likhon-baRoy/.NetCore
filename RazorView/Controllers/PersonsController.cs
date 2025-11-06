using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace RazorView.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonsService _personsService;

        public PersonsController(IPersonsService personsService)
        {
            _personsService = personsService;
        }

        [Route("persons/index")]
        public ActionResult Index()
        {
            List<PersonResponse> persons = _personsService.GetAllPersons();
            return View(persons);
        }

    }
}
