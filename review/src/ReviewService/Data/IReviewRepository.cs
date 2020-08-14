using System.Collections.Generic;
using ReviewService.Domain;

namespace ReviewService.Data
{
    public interface IReviewRepository
    {
        bool SaveChanges();
        IEnumerable<Review> GetReviews();
        Review GetReviewById(string id);
        void CreateReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(Review review);
    }
}