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

        public EventService()
        {
            _context = new EventManagerContext();
        }

        public EventDto CreateEvent(CreateEventDto addEventDto)
        {
            if(!_context.SimpleUsers.Any(x=>x.Id == addEventDto.OwnerId))
            {
                return null;
            }

            var eventDB = new Event()
            {
                OwnerId = addEventDto.OwnerId,
                Description = addEventDto.Description,
                Name = addEventDto.Name,
                StartDate = addEventDto.StartDate,
                EndDate = addEventDto.EndDate,
                ParticipantNumber = addEventDto.ParticipantNumber
            };

            _context.Events.Add(eventDB);
            _context.SaveChanges();

            var eventDto = new EventDto()
            {
                Id = eventDB.Id,
                OwnerId = eventDB.OwnerId.Value,
                Name = eventDB.Name,
                StartDate = eventDB.StartDate,
                EndDate = eventDB.EndDate,
                ParticipantNumber = eventDB.ParticipantNumber,
                Description = eventDB.Description
            };

            return eventDto;
        }
    }
}
