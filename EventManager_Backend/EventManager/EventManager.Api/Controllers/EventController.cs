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
            var events = _eventService.GetAll();

            var eventViewModelList = Mapper.Map<List<EventViewModel>>(events);

            return Ok(eventViewModelList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _eventService.GetEventById(id);

            if (result == null)
                return BadRequest();

            var mappedEvents = Mapper.Map<EventViewModel>(result);

            return Ok(mappedEvents);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateEventViewModel createEventViewModel)
        {
            if ((createEventViewModel.StartDate < DateTime.Now)
                || (createEventViewModel.StartDate > createEventViewModel.EndDate))
            {
                return BadRequest();
            }

            var eventDto = Mapper.Map<EventDto>(createEventViewModel);
            var createdEvent = _eventService.CreateEvent(eventDto);

            createEventViewModel = Mapper.Map<CreateEventViewModel>(createdEvent);

            if (createEventViewModel == null)
            {
                return BadRequest();
            }

            return Ok(createEventViewModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateEventViewModel updateEventViewModel)
        {
            var eventDto = Mapper.Map<EventDto>(updateEventViewModel);

            var updatedEvent = _eventService.UpdateEvent(eventDto);
            updateEventViewModel = Mapper.Map<UpdateEventViewModel>(updatedEvent);

            if (updateEventViewModel == null)
            {
                return BadRequest();
            }

            if ((updateEventViewModel.StartDate < DateTime.Now)
             || (updateEventViewModel.StartDate > updateEventViewModel.EndDate))
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