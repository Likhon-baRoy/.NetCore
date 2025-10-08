using Microsoft.AspNetCore.Mvc;

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
  }
}
