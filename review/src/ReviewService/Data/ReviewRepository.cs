using System;
using System.Collections.Generic;
using ReviewService.Domain;

namespace ReviewService.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ReviewServiceContext _context;

        public ReviewRepository(ReviewServiceContext context)
        {
            _context = context;
        }

        public void CreateReview(Review review)
        {
            if (review == null)
            {
                throw new ArgumentNullException(nameof(review));
            }

            _context.Reviews.Add(review);
        }

        public void DeleteReview(Review review)
        {
            throw new System.NotImplementedException();
        }

        public Review GetReviewById(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Review> GetReviews()
        {
            return _context.Reviews;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateReview(Review review)
        {
            throw new System.NotImplementedException();
        }
    }
}