using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Api.ViewModels;
using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _lectureService.GetOne(id);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateLectureViewModel createLectureViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var lectureDto = _iMapper.Map<LectureDto>(createLectureViewModel);
            var result = _lectureService.AddLecture(lectureDto);

            createLectureViewModel = _iMapper.Map<CreateLectureViewModel>(result);

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