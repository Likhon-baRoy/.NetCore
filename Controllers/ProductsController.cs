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

    [Route("search-products")]
    public ActionResult Search()
    {
      return View();
    }

    [Route("order-product")]
    public ActionResult Order()
    {
      return View();
    }
  }
}
