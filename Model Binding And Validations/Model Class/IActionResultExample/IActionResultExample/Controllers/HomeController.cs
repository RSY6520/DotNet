using IActionResultExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index([FromQuery] int? bookid, [FromRoute] bool? isloggedin, Book book)
        {
            if (bookid.HasValue == false)
            {
                return BadRequest("Bookid not supplied or empty");
            }
            //Book id can't be less than or equal to 0
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be less than or equal to 0");
            }

            //Book id should be between 1 to 1000
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be less than or equal to zero");
            }
            if (bookid > 1000)
            {
                return NotFound("Book id can't be greater than 1000");
            }

            //isloggedin should be true
            if (isloggedin == false)
            {
                return StatusCode(401);
            }

            return Content($"Book id: {bookid}, Book: {book}", "text/plain");
        }
    }
}