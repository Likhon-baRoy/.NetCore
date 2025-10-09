using Microsoft.AspNetCore.Mvc;

namespace RazorView.Controllers
{
  public class ProductsController : Controller
  {
    [Route("products")]
    public ActionResult Index()
    {
      ViewData["ListTitle"] = "Products";
      ViewData["ListItems"] = new List<string>()
      {
        "ThinkPad Yoga",
        "Andriod",
        "Earphone",
        "Mobile Charger",
        "Wallet",
        "Pen Driver",
        "Water Bottle"
      };

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
  }
}
