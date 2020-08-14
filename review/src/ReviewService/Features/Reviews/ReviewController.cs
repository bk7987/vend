using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ReviewService.Data;
using ReviewService.Domain;

namespace ReviewService.Features.Reviews
{
    [Route("/")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewReadDto>> GetReviews()
        {
            var reviews = _repository.GetReviews();
            return Ok(_mapper.Map<IEnumerable<ReviewReadDto>>(reviews));
        }

        [HttpGet("{id}")]
        public ActionResult GetReviewById()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<ReviewReadDto> CreateReview(ReviewCreateDto reviewCreateDto)
        {
            var review = _mapper.Map<Review>(reviewCreateDto);
            _repository.CreateReview(review);
            _repository.SaveChanges();

            var reviewReadDto = _mapper.Map<ReviewReadDto>(review);
            return CreatedAtRoute(nameof(GetReviewById), new { Id = reviewReadDto.Id }, reviewReadDto);
        }
    }
}