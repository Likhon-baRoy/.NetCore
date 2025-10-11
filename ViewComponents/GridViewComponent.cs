using Microsoft.AspNetCore.Mvc;
using RazorView.Models;

namespace RazorView.ViewComponents;

public class GridViewComponent : ViewComponent
{
  public async Task<IViewComponentResult> InvokeAsync()
  {
    PersonGridModel model = new PersonGridModel()
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
    ViewData["Grid"] = model;
    return View(); /* Invoked a partial view & path is: Views/Shared/Components/Grid/Default.cshtml */
  }
}
