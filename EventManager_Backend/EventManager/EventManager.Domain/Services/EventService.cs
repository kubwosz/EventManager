using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManager.Domain.Services
{
    public class EventService : IEventService
    {
        private readonly EventManagerContext _context;
        private readonly IMapper _iMapper;

        public EventService(IMapper iMapper, EventManagerContext context)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public EventDto CreateEvent(CreateEventDto addEventDto)
        {
            if(!_context.SimpleUsers.Any(x=>x.Id == addEventDto.OwnerId))
            {
                return null;
            }

            if(DateTime.Compare(addEventDto.StartDate, DateTime.Now) <= 0
                || DateTime.Compare(addEventDto.StartDate, addEventDto.EndDate) >= 0)
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
            var @event = _iMapper.Map<Event>(updateEventDto);

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
            var @event = _context.Events.SingleOrDefault(x => x.Id == id);

            if (@event == null)
            {
                return false;
            }

            _context.Events.Remove(@event);
            return _context.SaveChanges() > 0;
        }
    }
}
