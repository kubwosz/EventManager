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
        private readonly IMapper _iMapper;

        public EventController(IEventService eventService, IMapper iMapper)
        {
            _eventService = eventService;
            _iMapper = iMapper;
        }

        [HttpGet]
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
        public IActionResult Post([FromBody] CreateEventViewModel createEventViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var eventDto = _iMapper.Map<EventDto>(createEventViewModel);
            var result = _eventService.CreateEvent(eventDto);

            createEventViewModel = _iMapper.Map<CreateEventViewModel>(result);
            return Ok(createEventViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateEventViewModel updateEventViewModel)
        {
            if (updateEventViewModel.Id == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var eventDto = _iMapper.Map<EventDto>(updateEventViewModel);

            var result = _eventService.UpdateEvent(eventDto);
            updateEventViewModel = _iMapper.Map<UpdateEventViewModel>(result);

            return Ok(updateEventViewModel);
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
