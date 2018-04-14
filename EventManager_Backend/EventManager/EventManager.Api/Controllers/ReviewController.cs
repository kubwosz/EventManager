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
        private readonly IMapper _iMapper;

        public ReviewController(IReviewService reviewService, IMapper iMapper)
        {
            _reviewService = reviewService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _reviewService.GetAll();
            var reviewViewModelList = _iMapper.Map<List<ReviewViewModel>>(result);

            return Ok(reviewViewModelList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _reviewService.GetOne(id);

            if (result == null)
                return BadRequest();

            var reviewViewModel = _iMapper.Map<ReviewViewModel>(result);

            return Ok(reviewViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateReviewViewModel createReviewViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var reviewDto = _iMapper.Map<ReviewDto>(createReviewViewModel);
            var result = _reviewService.CreateReview(reviewDto);

            createReviewViewModel = _iMapper.Map<CreateReviewViewModel>(result);
            return Ok(createReviewViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateReviewViewModel updateReviewViewModel)
        {
            if (updateReviewViewModel.Id == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var reviewDto = _iMapper.Map<ReviewDto>(updateReviewViewModel);

            var result = _reviewService.UpdateReview(reviewDto);
            updateReviewViewModel = _iMapper.Map<UpdateReviewViewModel>(result);

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
