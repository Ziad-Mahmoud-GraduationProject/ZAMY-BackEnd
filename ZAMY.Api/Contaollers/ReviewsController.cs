using Bookify.Domain.Consts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZAMY.Application.Services.Reviews;
using ZAMY.Domain.Entities;

namespace ZAMY.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController(IReviewService _reviewService,
        IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var reviews= _reviewService.GetAll();
            if(reviews is null)
                return NotFound("Not Found any Review");
           return Ok( _mapper.Map<IEnumerable<ReviewDto>>(reviews));
        }
        [HttpGet("NewersReview")]
        public IActionResult NewersReview()
        {
            var reviews = _reviewService.NewersReview();
            if (reviews is null)
                return NotFound("Not Found any Review");
            return Ok(_mapper.Map<IEnumerable<ReviewDto>>(reviews));
        }
        [HttpGet("OldersReview")]
        public IActionResult OldersReview()
        {
            var reviews = _reviewService.OldersReview();
            if (reviews is null)
                return NotFound("Not Found any Review");
            return Ok(_mapper.Map<IEnumerable<ReviewDto>>(reviews));
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id) 
        {
            var review = _reviewService.GetById(id);
            if (review is null)
                return NotFound($"Not Found any Review has {id} Id");
            return Ok(_mapper.Map<ReviewDto>(review));
        }
        [HttpPost("Add")]
        public IActionResult Add(CreateReview dto)
        {
            var review = _mapper.Map<Review>(dto);
            _reviewService.Add(review);
            return Ok(review);
        }
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id,EditReview dto)
        {
            var review = _reviewService.GetById(id);
            if (review is null)
                return NotFound($"Not Found any Review has {id} Id");
            review.Comment = dto.Comment;
            review.KitchenRating = dto.KitchenRating;
            review.DeliveryServiceRating= dto.DeliveryServiceRating;
            review.CustomerId= dto.CustomerId;
            review.OrderId= dto.OrderId;
            _reviewService.Update(review);
            return Ok(review);
        }
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var review = _reviewService.GetById(id);
            if (review is null)
                return NotFound($"Not Found any Review has {id} Id");
            _reviewService.Delete(review);
            return Ok(review);
        }
    }
}
