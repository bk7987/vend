using System.ComponentModel.DataAnnotations;

namespace ReviewService.Data
{
    public class ReviewCreateDto
    {
        [Required]
        public int Rating { get; set; }

        public string ReviewText { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}