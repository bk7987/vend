using ReviewService.Domain;
using Microsoft.EntityFrameworkCore;

namespace ReviewService.Data
{
    public class ReviewServiceContext : DbContext
    {
        public ReviewServiceContext(DbContextOptions<ReviewServiceContext> opt) : base(opt) { }

        public DbSet<Review> Reviews { get; set; }
    }
}