using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManager.Domain.Services
{
    public class EventService
    {
        private readonly EventManagerContext _context;
        private readonly IMapper _iMapper;

        public EventService(IMapper iMapper)
        {
            _context = new EventManagerContext();
            _iMapper = iMapper;
        }

        public EventDto CreateEvent(CreateEventDto addEventDto)
        {
            if(!_context.SimpleUsers.Any(x=>x.Id == addEventDto.OwnerId))
            {
                return null;
            }

            var @event = _iMapper.Map<Event>(addEventDto);

            _context.Events.Add(@event);
            _context.SaveChanges();

            var eventDto = _iMapper.Map<EventDto>(@event);

            return eventDto;
        }

        public EventDto UpdateEvent(UpdateEventDto updateEventDto)
        {
            Event @event = new Event
            {
                Id = updateEventDto.Id,
                OwnerId = updateEventDto.OwnerId,
                Name = updateEventDto.Name,
                StartDate = updateEventDto.StartDate,
                EndDate = updateEventDto.EndDate,
                ParticipantNumber = updateEventDto.ParticipantNumber,
                Description = updateEventDto.Description
            };

            _context.Events.Update(@event);
            _context.SaveChanges();

            var eventDto = _iMapper.Map<EventDto>(@event);

            return eventDto;
        }

        public List<EventDto> GetAll()
        {
            var events = _context.Events;

            if (events == null)
                return null;

            List<EventDto> eventDtoList = _iMapper.Map<List<EventDto>>(events);

            return eventDtoList;
        }

        public bool DeleteEvent(int id)
        {
            var @event = _context.Events.FirstOrDefault(x => x.Id == id);

            if (@event == null)
            {
                return false;
            }

            _context.Events.Remove(@event);
            _context.SaveChanges();
            return true;
        }
    }
}
