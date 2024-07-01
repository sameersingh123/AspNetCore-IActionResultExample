using IActionResultExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        //[Route("bookstore")]
        //URL: http://localhost:5000/bookstore/boodid=8&isLoggedIn=true
        //public IActionResult Index()
        //{
        //    //BookId is not supplied in the query string
        //    if (!Request.Query.ContainsKey("bookId"))
        //    {
        //        //Response.StatusCode = 400;
        //        //return Content("Bookid is not present in the query string");

        //        //OR

        //        return BadRequest("Book Id is not present in the query string");

        //    }

        //    //BookId value cannot be empty
        //    if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookId"])))
        //    {
        //        Response.StatusCode = 400;
        //        return Content("Bookid is empty in the query string");
        //    }


        //    //BookId supplied should be between 1 and 1000
        //    int bookId = Convert.ToInt32(Request.Query["bookId"]);
        //    if (bookId < 1)
        //    {
        //        Response.StatusCode = 400;
        //        return Content("Bookid is less than 1 in the query string");
        //    }
        //    if (bookId > 1000)
        //    {
        //        Response.StatusCode = 400;
        //        return Content("BookId should not be greater than 1000");
        //    }

        //    //isLoggedIn should be true
        //    if (Convert.ToBoolean(Request.Query["isLoggedIn"]) == false)
        //    {
        //        //Response.StatusCode = 401;
        //        //return Content("User must be authenticated");

        //        //OR

        //        return Unauthorized("User must be authenticated");
        //    }

        //    //return File("/carimg.jpg", "image/jpeg");

        //    //return new RedirectToActionResult("Books", "Store", new { }/*, permanent:true*/);  // 302-Found without permanent:true   and 301- moved permanently with permanent:true

        //     return RedirectToAction("Books", "Store", new { id = bookId });  // 302-Found
        //    //return RedirectToActionPermanent("Books", "Store", new { id = bookId });  //301-Moved Permanently
        //}

        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index(/*[FromQuery]*/ int? bookid, [FromRoute] bool? isloggedin, Book book)
        {
            if (bookid.HasValue == false)            //these are called validations
            {
                return BadRequest("Book Id is not present in query string or is empty");
            }
            if(bookid<=0)                    
            {
                return BadRequest("Book Id should be greater than 0");
            }
            if (bookid > 1000)
            {
                return BadRequest("book id should not be greater than 1000");
            }

            if (isloggedin==false)
            {
                return Unauthorized("User must be authenticated");
            }

            return Content($"book id: {bookid}, Book:{book}", "text/plain");
        }
    }
}
