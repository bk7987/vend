using Microsoft.AspNetCore.Mvc;

namespace ReviewService.Features.Reviews
{
    [Route("/")]
    public class ReviewController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllReviews()
        {
            System.Console.WriteLine("testing");
            return Ok("testing 121fddf3ldfjsdlfksldkjfd4a");
        }
    }
}