using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;



namespace EventManager.Domain.Services
{
    public class EventService : IEventService
    {
        private readonly EventManagerContext _context;

        public EventService(EventManagerContext context)
        {
            _context = context;
        }

        public EventDto CreateEvent(EventDto eventDto)
        {
            if(!_context.SimpleUsers.Any(x=>x.Id == eventDto.OwnerId))
            {
                return null;
            }
             
            var @event = Mapper.Map<Event>(eventDto);

            _context.Events.Add(@event);
            _context.SaveChanges();

           eventDto = Mapper.Map<EventDto>(@event);

            return eventDto;
        }

        public EventDto UpdateEvent(EventDto eventDto)
        {
            var @event = Mapper.Map<Event>(eventDto);

            _context.Events.Update(@event);
            _context.SaveChanges();

            eventDto = Mapper.Map<EventDto>(@event);

            return eventDto;
        }

        public EventDto GetEventById(int id)
        {
            var @event = _context.Events.SingleOrDefault(x => x.Id == id);

            if (@event == null)
            {
                return null;
            }

            EventDto eventDto = Mapper.Map<EventDto>(@event);

            return eventDto;
        }

        public List<EventDto> GetAll()
        {
            var events = _context.Events;

            if (events == null)
                return null;

            List<EventDto> eventDtoList = Mapper.Map<List<EventDto>>(events);

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
            var result = _context.SaveChanges();
            
            return result > 0;
        }
    }
}
