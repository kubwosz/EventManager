using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


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
            var reviews = _reviewService.GetAll();
            var reviewViewModelList = Mapper.Map<List<ReviewViewModel>>(reviews);

            return Ok(reviewViewModelList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var reviewDto = _reviewService.GetReviewById(id);

            if (reviewDto == null)
                return BadRequest();

            var reviewViewModel = Mapper.Map<ReviewViewModel>(reviewDto);

            return Ok(reviewViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateReviewViewModel createReviewViewModel)
        {
            var reviewDto = Mapper.Map<ReviewDto>(createReviewViewModel);
            var createdReview = _reviewService.CreateReview(reviewDto);

            createReviewViewModel = Mapper.Map<CreateReviewViewModel>(createdReview);

            if (createReviewViewModel == null)
            {
                return BadRequest();
            }

            return Ok(createReviewViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateReviewViewModel updateReviewViewModel)
        {
            if (updateReviewViewModel.Id == 0)
            {
                return BadRequest();
            }

            var reviewDto = Mapper.Map<ReviewDto>(updateReviewViewModel);

            var updatedReview = _reviewService.UpdateReview(reviewDto);

            updateReviewViewModel = Mapper.Map<UpdateReviewViewModel>(updatedReview);

            if (updateReviewViewModel == null)
            {
                return BadRequest();
            }

            return Ok(updateReviewViewModel);
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