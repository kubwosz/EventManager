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
            var lectures = _lectureService.GetAll();
            var lectureViewModelList = Mapper.Map<List<LectureViewModel>>(lectures);

            return Ok(lectureViewModelList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var lecture = _lectureService.GetLectureById(id);

            if (lecture == null)
                return BadRequest();

            var lectureViewModel = Mapper.Map<LectureViewModel>(lecture);

            return Ok(lectureViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateLectureViewModel createLectureViewModel)
        {
            if (createLectureViewModel.StartDate > createLectureViewModel.EndDate)
            {
                BadRequest();
            }

            var lectureDto = Mapper.Map<LectureDto>(createLectureViewModel);
            var createdLecture = _lectureService.AddLecture(lectureDto);

            createLectureViewModel = Mapper.Map<CreateLectureViewModel>(createdLecture);

            if (createLectureViewModel == null)
            {
                return BadRequest();
            }

            return Ok(createLectureViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateLectureViewModel updateLectureViewModel)
        {
            var lectureDto = Mapper.Map<LectureDto>(updateLectureViewModel);

            var updatedLecture = _lectureService.UpdateLecture(lectureDto);
            updateLectureViewModel = Mapper.Map<UpdateLectureViewModel>(updatedLecture);

            if (updateLectureViewModel == null)
            {
                return BadRequest();
            }

            if (updateLectureViewModel.StartDate > updateLectureViewModel.EndDate)
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