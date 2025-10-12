using Microsoft.AspNetCore.Mvc;
using RazorView.Models;

namespace RazorView.Controllers
{
  public class ProductsController : Controller
  {
    [Route("products")]
    public ActionResult Index()
    {
      return View();
    }

    [Route("search-products/{ProductID?}")]
    public ActionResult Search(int? ProductID)
    {
      ViewBag.Path = "search-products";
      ViewBag.ProductID = ProductID;
      return View();
    }

    [Route("order-product")]
    public ActionResult Order()
    {
      return View();
    }

    [Route("programming-languages")]
    public IActionResult ProgrammingLanguages()
    {
      ListModel listModel = new ListModel()
      {
        ListTitle = "Programming Languages List",
        ListItems = new List<string>()
        {
          "C",
          "C#",
          "C++",
          "PHP",
          "Java",
          "Python"
        }
      };

      return PartialView("_ListPartialView", listModel);
    }

    [Route("friends-list")]
    public ActionResult LoadFriendsList()
    {
      PersonGridModel personGridModel = new PersonGridModel()
      {
        GridTitle = "Friends",
        Persons = new List<Person>
        {
          new Person { Name = "Mia", JobTitle = "Developer" },
          new Person { Name = "Emma", JobTitle = "UI/UX Designer" },
          new Person { Name = "Avva", JobTitle = "SQA Engineer" }
        }
      };

      return ViewComponent("Grid", new
      {
        grid = personGridModel
      });
    }
  }
}
