using Microsoft.AspNetCore.Mvc;

namespace IActionResultEx.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books")]
        //[Route("store/books/{id}")]
        public IActionResult Books()
        {
            return Content("redirected result");
        }
    }
}
