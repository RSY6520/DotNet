using Microsoft.AspNetCore.Mvc;

namespace IActionResultEx.Controllers
{
    public class HomeController : Controller
    {
        //[Route("book")]
        [Route("bookstore")]
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                Response.StatusCode = 400;
                return Content("Book id is not supplied");
            }

            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookId"]);
            if(bookId <= 0)
            {
                return BadRequest("Book id can't be less than or equal to 0");
            }

            if (bookId > 1000) { 
                return NotFound("Book not found");
            }

            if (!Convert.ToBoolean(Request.Query.ContainsKey("isLoggedIn")))
            {
                return StatusCode(401);
            }

            //return File("/sample.pdf", "application/pdf");
            //return new RedirectToActionResult("Books", "Store", new { });
            //return new RedirectToActionResult("Books", "Store", new { }, true);
            //return RedirectToAction("Books", "Store", new { id = bookId });
            //return RedirectToActionPermanent("Books", "Store", new { id = bookId });
            //return LocalRedirect($"store/books/{bookId}");
            //return new LocalRedirectResult($"store/books/{bookId}", true);
            //return LocalRedirectPermanent($"store/books/{bookId}");
            //return Redirect($"store/books/{bookId}");
            return RedirectPermanent("store/books");
        }
    }
}
