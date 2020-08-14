using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using ReviewService.Data;

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
    }
}