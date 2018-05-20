using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

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
        public IActionResult Get()
        {
            var result = _eventService.GetAll();

            var eventViewModelList = Mapper.Map<List<EventViewModel>>(result);

            return Ok(eventViewModelList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _eventService.GetEventById(id);

            if (result == null)
                return BadRequest();
            
            var eventViewModel = Mapper.Map<EventViewModel>(result);

            return Ok(eventViewModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateEventViewModel createEventViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if ( (createEventViewModel.StartDate.Ticks < DateTime.Now.Ticks)
                || (createEventViewModel.StartDate.Ticks > createEventViewModel.EndDate.Ticks))
            {
                return BadRequest();
            }

            var eventDto = Mapper.Map<EventDto>(createEventViewModel);
            var result = _eventService.CreateEvent(eventDto);

            createEventViewModel = Mapper.Map<CreateEventViewModel>(result);

            if(createEventViewModel == null)
            {
                return BadRequest();
            }

            return Ok(createEventViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateEventViewModel updateEventViewModel)
        {
            if (updateEventViewModel.Id == 0 || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var eventDto = Mapper.Map<EventDto>(updateEventViewModel);

            var result = _eventService.UpdateEvent(eventDto);
            updateEventViewModel = Mapper.Map<UpdateEventViewModel>(result);
            
            if(updateEventViewModel == null)
            {
                return BadRequest();
            }

            if ((updateEventViewModel.StartDate.Ticks < DateTime.Now.Ticks)
             || (updateEventViewModel.StartDate.Ticks > updateEventViewModel.EndDate.Ticks))
            {
                return BadRequest();
            }

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
