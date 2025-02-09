using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "ASP.NET core App";

            List<Person> people = new List<Person>()
            {
                new Person() { Name = "Aman", DateOfBirth = DateTime.Parse("1990-05-06"), PersonGender = Gender.Male },
                new Person() { Name = "Bala", DateOfBirth = DateTime.Parse("1995-05-06"), PersonGender = Gender.Male },
                new Person() { Name = "Corrot", DateOfBirth = DateTime.Parse("1999-05-06"), PersonGender = Gender.Male }
            };
            ViewData["people"] = people;
            ViewBag.pople = people;
            return View();
        }
    }
}
