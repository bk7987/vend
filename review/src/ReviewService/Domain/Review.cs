using System.ComponentModel.DataAnnotations;

namespace ReviewService.Domain
{
    public class Review
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public int Upvotes { get; set; }

        public string ReviewText { get; set; }
    }
}
