using System;

namespace ReviewService.Domain
{
    public class ReviewService
    {
        public string Id { get; set; }

        public int Rating { get; set; }

        public int Upvotes { get; set; }

        public string ReviewText { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
