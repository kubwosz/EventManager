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

        public EventService(IMapper iMapper)
        {
            _context = new EventManagerContext();
            _iMapper = iMapper;
        }

        public EventDto CreateEvent(EventDto eventDto)
        {
            if(!_context.SimpleUsers.Any(x=>x.Id == eventDto.OwnerId))
            {
                return null;
            }

            var @event = _iMapper.Map<Event>(eventDto);

            _context.Events.Add(@event);
            _context.SaveChanges();

           eventDto = _iMapper.Map<EventDto>(@event);

            return eventDto;
        }

        public EventDto UpdateEvent(EventDto eventDto)
        {
            var @event = _iMapper.Map<Event>(eventDto);

            _context.Events.Update(@event);
            _context.SaveChanges();

            eventDto = _iMapper.Map<EventDto>(@event);

            return eventDto;
        }

        public EventDto GetOne(int id)
        {
            var @event = _context.Events.FirstOrDefault(x => x.Id == id);

            if (@event == null)
            {
                return null;
            }

            EventDto eventDto = _iMapper.Map<EventDto>(@event);

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

            var result = _context.SaveChanges();
            return result > 0;
        }
    }
}
