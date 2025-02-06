using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{
    public class Book
    {
        [FromQuery]
        public int? Id { get; set; }

        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book object, BookId: {Id} Author: {Author}";
        }
    }
}
