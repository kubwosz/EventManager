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
    [Route("api/review")]
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(_reviewService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (_reviewService.GetOne(id) == null)
                return BadRequest();

            return Ok(_reviewService.GetOne(id));
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ReviewDto createReviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_reviewService.CreateReview(createReviewDto));
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] ReviewDto updateReviewDto)
        {
            if (updateReviewDto.Id != 0 && !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_reviewService.UpdateReview(updateReviewDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_reviewService.DeleteReview(id))
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
