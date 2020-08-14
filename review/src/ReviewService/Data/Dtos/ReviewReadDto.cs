namespace ReviewService.Data
{
    public class ReviewReadDto
    {
        public string Id { get; set; }
        public int Rating { get; set; }
        public int UpVotes { get; set; }
        public string ReviewText { get; set; }
        public string UserId { get; set; }
    }
}