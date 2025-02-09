using Microsoft.AspNetCore.Mvc;
using StronglyTypedViews.Models;
using static StronglyTypedViews.Models.Person;

namespace StronglyTypedViews.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp.Net Core Demo App";

            List<Person> people = new List<Person>()
              {
                  new Person() { Name = "John", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
                  new Person() { Name = "Linda", DateOfBirth = DateTime.Parse("2005-01-09"), PersonGender = Gender.Female},
                  new Person() { Name = "Susan", DateOfBirth = null, PersonGender = Gender.Other}
              };
            return View("Index", people);
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Person name can't be null");
            }

            List<Person> people = new List<Person>()
              {
                  new Person() { Name = "John", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
                  new Person() { Name = "Linda", DateOfBirth = DateTime.Parse("2005-01-09"), PersonGender = Gender.Female},
                  new Person() { Name = "Susan", DateOfBirth = null, PersonGender = Gender.Other}
              };

            Person? matchingPerson = people.Where(people => people.Name == name).FirstOrDefault();

            if (matchingPerson == null)
            {
                return Content("Person not found");
            }

            return View(matchingPerson);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person()
            {
                Name = "John",
                PersonGender = Gender.Male,
                DateOfBirth = DateTime.Parse("2000-05-06"),
            };
            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "Laptop"
            };

            PersonAndProductWrapperModel personAndProduct = new PersonAndProductWrapperModel()
            {
                PersonData = person,
                ProductData = product
            };
            return View(personAndProduct);
        }

        [Route("home/all-products")]
        public IActionResult All()
        {
            return View();
            //Views/Home/All.cshtml
            //Views/Shared/All.cshtml
        }
    }
}
