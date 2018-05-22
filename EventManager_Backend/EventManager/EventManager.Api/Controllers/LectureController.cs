using AutoMapper;
using EventManager.Api.ViewModels;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EventManager.Api.Controllers
{
    [Route("api/lecture")]
    public class LectureController : Controller
    {
        private readonly ILectureService _lectureService;

        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _lectureService.GetAll();
            var lectureViewModelList = Mapper.Map<List<LectureViewModel>>(result);

            return Ok(lectureViewModelList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _lectureService.GetLectureById(id);

            if (result == null)
                return BadRequest();

            var lectureViewModel = Mapper.Map<LectureViewModel>(result);

            return Ok(lectureViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateLectureViewModel createLectureViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (createLectureViewModel.StartDate.Ticks > createLectureViewModel.EndDate.Ticks )
            {
                BadRequest();
            }

            var lectureDto = Mapper.Map<LectureDto>(createLectureViewModel);
            var result = _lectureService.AddLecture(lectureDto);

            createLectureViewModel = Mapper.Map<CreateLectureViewModel>(result);

            if(createLectureViewModel == null)
            {
               return BadRequest(); 
            }

            return Ok(createLectureViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateLectureViewModel updateLectureViewModel)
        {
            if (updateLectureViewModel.Id == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var lectureDto = Mapper.Map<LectureDto>(updateLectureViewModel);

            var result = _lectureService.UpdateLecture(lectureDto);
            updateLectureViewModel = Mapper.Map<UpdateLectureViewModel>(result);

            if(updateLectureViewModel == null)
            {
                return BadRequest();
            }

            if (updateLectureViewModel.StartDate.Ticks > updateLectureViewModel.EndDate.Ticks)
            {
                BadRequest();
            }

            return Ok(updateLectureViewModel);
        }

        [HttpDelete] 
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _lectureService.Delete(id);

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}