using Microsoft.AspNetCore.Mvc;

namespace StronglyTypedViews.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products/all")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
