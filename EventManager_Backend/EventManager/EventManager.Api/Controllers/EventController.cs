using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(IMapper iMapper)
        {
            _eventService = new EventService(iMapper);
        }

        [HttpPost]
        [Route("CreateEvent")]
        public IActionResult CreateEvent([FromBody] CreateEventDto createEventDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_eventService.CreateEvent(createEventDto));
        }

        [HttpPut]
        [Route("UpdateEvent")]
        public IActionResult UpdateEvent([FromBody] UpdateEventDto updateEventDto)
        {
            if (updateEventDto.Id!=0 && !ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_eventService.UpdateEvent(updateEventDto));
        }

        [HttpGet]
        [Route("Events")]
        public IActionResult GetAllEvents()
        {
            return Ok(_eventService.GetAll());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            if (!_eventService.DeleteEvent(id))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
