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
        public IActionResult Get()
        {
            var result = _reviewService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _reviewService.GetOne(id);
            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReviewDto createReviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _reviewService.CreateReview(createReviewDto);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ReviewDto updateReviewDto)
        {
            if (updateReviewDto.Id == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _reviewService.UpdateReview(updateReviewDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _reviewService.DeleteReview(id);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
