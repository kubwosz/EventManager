using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Api.ViewModels;
using EventManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers
{
    [Route("api/event")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var result = _eventService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (_eventService.GetOne(id) == null)
                return BadRequest();

            var result = _eventService.GetOne(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] EventDto createEventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _eventService.CreateEvent(createEventDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("")]
        public IActionResult Put([FromBody] EventDto updateEventDto)
        {
            if (updateEventDto.Id == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _eventService.UpdateEvent(updateEventDto);
            return Ok(result);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_eventService.DeleteEvent(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
