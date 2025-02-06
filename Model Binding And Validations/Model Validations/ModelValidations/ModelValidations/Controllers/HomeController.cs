using Microsoft.AspNetCore.Mvc;
using ModelValidations.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            return Content($"{person}");
        }
    }
}