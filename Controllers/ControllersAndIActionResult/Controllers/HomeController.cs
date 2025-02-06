using System;
using ControllersAndIActionResult.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndIActionResult.Controllers
{
    public class HomeController : Controller
    {
        //[Route("home")]
        //[Route("/")]
        //public string Index()
        //{
        //    return "Hello from index";
        //}

        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("<h1>Welcome</h1>", "text/html");
        }

        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from contact";
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ramakant",
                LastName = "Yadav",
                Age = 15
            };
            return Json(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload() 
        {
            //return new VirtualFileResult("/sample.pdf", "application/pdf");
            return File("/sample.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2() 
        {
            //return new PhysicalFileResult(@"C:\Users\rsy65\Downloads\sample2.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\rsy65\Downloads\sample2.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\rsy65\Downloads\sample2.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }

    }
}
