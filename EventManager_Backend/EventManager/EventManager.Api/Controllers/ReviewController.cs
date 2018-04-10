using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult GetAllReviews()
        {
            return Ok(_reviewService.GetAll());
        }

        [HttpPost]
        [Route("CreateReview")]
        public IActionResult CreateReview([FromBody] CreateReviewDto createReviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_reviewService.CreateReview(createReviewDto));
        }

        [HttpPut]
        [Route("UpdateReview")]
        public IActionResult UpdateReview([FromBody] UpdateReviewDto updateReviewDto)
        {
            if (updateReviewDto.Id != 0 && !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_reviewService.UpdateReview(updateReviewDto));
        }

        [HttpDelete]
        [Route("DeleteReview/{id}")]
        public IActionResult DeleteReview(int id)
        {
            if (!_reviewService.DeleteReview(id))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
