using System;
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

        [Route("contact")]
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
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };

            return Json(person);
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            return File("/sample.pdf", "application/pdf");  // Serves from wwwroot
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            return PhysicalFile(@"c:\aspnetcore\sample.pdf", "application/pdf"); // Full path
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"c:\aspnetcore\sample.pdf");
            return File(bytes, "application/pdf");  // In-memory bytes
        }

        [Route("book")]
        public IActionResult Book()
        {
            // Book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400; // Setting status code manually
                return Content("Book id is not supplied");
            }

            // ... other validation checks ...

            // If all checks pass
            return File("/sample.pdf", "application/pdf");
        }

        
    }

    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
