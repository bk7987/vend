using AutoMapper;
using ReviewService.Data;
using ReviewService.Domain;

namespace ReviewService.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewReadDto>();
        }
    }
}