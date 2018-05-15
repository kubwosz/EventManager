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
        private readonly IMapper _iMapper;

        public LectureController(ILectureService lectureService, IMapper iMapper)
        {
            _lectureService = lectureService;
            _iMapper = iMapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _lectureService.GetAll();
            var lectureViewModelList = _iMapper.Map<List<LectureViewModel>>(result);

            return Ok(lectureViewModelList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _lectureService.GetOne(id);

            if (result == null)
                return BadRequest();

            var lectureViewModel = _iMapper.Map<LectureViewModel>(result);

            return Ok(lectureViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateLectureViewModel createLectureViewModel)
        {

            var lectureDto = _iMapper.Map<LectureDto>(createLectureViewModel);
            var result = _lectureService.AddLecture(lectureDto);

            createLectureViewModel = _iMapper.Map<CreateLectureViewModel>(result);

            if(createLectureViewModel == null)
            {
                BadRequest(); 
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

            var lectureDto = _iMapper.Map<LectureDto>(updateLectureViewModel);

            var result = _lectureService.UpdateLecture(lectureDto);
            updateLectureViewModel = _iMapper.Map<UpdateLectureViewModel>(result);

            if(updateLectureViewModel == null)
            {
                return BadRequest();
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