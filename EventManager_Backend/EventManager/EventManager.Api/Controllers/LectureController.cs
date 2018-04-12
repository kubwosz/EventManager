using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpGet]
        [Route("")]
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
        [Route("")]
        public IActionResult Post([FromBody] LectureDto addLectureDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _lectureService.AddLecture(addLectureDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] LectureDto updateLectureDto)
        {
            if (updateLectureDto.Id == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _lectureService.UpdateLecture(updateLectureDto);
            return Ok(result);
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