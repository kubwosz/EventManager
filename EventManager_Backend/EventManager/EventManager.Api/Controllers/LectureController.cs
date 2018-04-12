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

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] LectureDto addLectureDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_lectureService.AddLecture(addLectureDto));
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return Ok(_lectureService.GetAll());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (_lectureService.GetOne(id) == null)
                return BadRequest();

            return Ok(_lectureService.GetOne(id));
        }
        

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] LectureDto updateLectureDto)
        {
            if (updateLectureDto.Id != 0 && !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_lectureService.UpdateLecture(updateLectureDto));
        }

        [HttpDelete] 
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_lectureService.Delete(id))
                return BadRequest();
            return Ok();
        }
    }
}