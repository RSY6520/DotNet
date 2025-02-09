using Microsoft.AspNetCore.Mvc;
using StronglyTypedPartialVies.Models;

namespace StronglyTypedPartialVies.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            ListModel listmodel = new ListModel();
            listmodel.ListTitle = "Programming Languages";
            listmodel.ListItems = new List<string>()
            {
                "C#",
                "Java",
                "Python",
                "JavaScript"
            };

            return PartialView(listmodel);
        }
    }
}
