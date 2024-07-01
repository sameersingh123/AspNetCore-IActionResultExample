using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{
    public class Book
    {
        //[FromQuery]
        public int? bookid { get; set; }

        public string? author { get; set; }

        public override string ToString()
        {
            return $"bookid: {bookid}, author: {author}";
        }
    }
}
