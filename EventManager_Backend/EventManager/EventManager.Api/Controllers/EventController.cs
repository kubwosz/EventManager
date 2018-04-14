using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

            var eventViewModelList = _iMapper.Map<List<EventViewModel>>(result);

            return Ok(eventViewModelList);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _eventService.GetOne(id);

            if (result == null)
                return BadRequest();
            
            var eventViewModel = _iMapper.Map<EventViewModel>(result);

            return Ok(eventViewModel);
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
