using Microsoft.AspNetCore.Mvc;
using RazorView.Models;

namespace RazorView.ViewComponents;

public class GridViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    PersonGridModel personGridModel = new PersonGridModel()
    {
      GridTitle = "Persons List from GridViewComponent",
      Persons = new List<Person>()
      {
        new Person()
        {
          Name = "John",
          JobTitle = "Manager"
        },
        new Person()
        {
          Name = "Jones",
          JobTitle = "Asst. Manager"
        },
        new Person()
        {
          Name = "William",
          JobTitle = "Clerk"
        }
      }
    };
    return View(personGridModel); /* Invoked a partial view & path is: Views/Shared/Components/Grid/Default.cshtml */
  }
}
