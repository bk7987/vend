using System.ComponentModel.DataAnnotations;
using NeoSmart.Utils;

namespace ReviewService.Domain
{
    public class Review
    {
        public Review()
        {
            var uuid = System.Text.Encoding.UTF8.GetBytes(System.Guid.NewGuid().ToString());
            Id = UrlBase64.Encode(uuid);
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public int Upvotes { get; set; }

        public string ReviewText { get; set; }
    }
}
