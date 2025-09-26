using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        [Route("home")] // one url for method1()
        [Route("/")] // another url for method1()
        public ContentResult Index()
        {
            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Bond",
                Age = 27
            };

            return Json(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload() // if file is inside of wwwroot folder
        {
            // return new VirtualFileResult("/sample.pdf", "application/pdf");
            return File("/sample.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2() // if file is outside of wwwroot folder
        {
            // return new PhysicalFileResult("/home/likhon/likhon.pdf", "application/pdf"); // have to provide the full path
            return PhysicalFile("/home/likhon/likhon.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3() // if is loaded from another data source as byte array as low level data
        {
            byte[] bytes = System.IO.File.ReadAllBytes("/home/likhon/likhon.pdf");
            // return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")] // only Digit & exactly 10 number
        public string Contact()
        {
            return "Hello from Contact";
        }

        // public ActionResult Index()
        // {
        //     return View();
        // }

    }
}
