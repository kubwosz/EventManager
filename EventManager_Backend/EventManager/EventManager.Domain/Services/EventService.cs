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
            if (!_context.SimpleUsers.Any(x => x.Id == addEventDto.OwnerId))
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

        public EventDto UpdateEvent(UpdateEventDto updateEventDto)
        {
            var todo = _context.Events.FirstOrDefault(x => x.Id == updateEventDto.Id);

            if (todo == null)
            {
                return null;
            }

            todo.OwnerId = updateEventDto.OwnerId;
            todo.Name = updateEventDto.Name;
            todo.StartDate = updateEventDto.StartDate;
            todo.EndDate = updateEventDto.EndDate;
            todo.ParticipantNumber = updateEventDto.ParticipantNumber;
            todo.Description = updateEventDto.Description;

            _context.Events.Update(todo);
            _context.SaveChanges();

            var eventDto = new EventDto()
            {
                Id = todo.Id,
                OwnerId = todo.OwnerId.Value,
                Name = todo.Name,
                StartDate = todo.StartDate,
                EndDate = todo.EndDate,
                ParticipantNumber = todo.ParticipantNumber,
                Description = todo.Description
            };

            return eventDto;
        }

        public List<EventDto> GetAll()
        {
            var result = _context.Events.Select(x => x);

            if (result == null)
            {
                return null;
            }

            List<EventDto> eventDtos = new List<EventDto>();

            foreach (var item in result)
            {
                eventDtos.Add(new EventDto()
                {
                    Id = item.Id,
                    OwnerId = item.OwnerId.Value,
                    Description = item.Description,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    ParticipantNumber = item.ParticipantNumber
                });
            }

            return eventDtos;
        }

        public bool DeleteEvent(int id)
        {
            var eventDB = _context.Events.FirstOrDefault(x => x.Id == id);

            if (eventDB == null)
            {
                return false;
            }

            _context.Events.Remove(eventDB);
            _context.SaveChanges();
            return true;
        }


        public bool RegistrationForEvent(SimpleUser simpleUser, EventDto eventDto)
        {

            if (!(_context.SimpleUsers.Any()) || !(_context.Events.Any()))
            {
                return false;
            }

            var userEventDB = new EventUser()
            {
                Id = simpleUser.Id,
                EventId = eventDto.Id,

            };

            _context.EventUsers.Add(userEventDB);
            _context.SaveChanges();

            return true;
        }

        public List<EventUserDto> GetEventUser()
        {
            var tmp = _context.EventUsers.Select(x => x);

            if (tmp == null)
            {
                return null;
            }


            List<EventUserDto> eventUserDtos = new List<EventUserDto>();

            foreach (var item in tmp)
            {
                eventUserDtos.Add(new EventUserDto()
                {
                    Id = item.Id,
                    EventId = item.EventId,
                    UserId = item.UserId,
                });

            }
            return eventUserDtos;
        }


        public bool SignForLecture(SimpleUser simpleUser, LectureDto lectureDto)
        {
            if (!(_context.SimpleUsers.Any()) || !(_context.Lectures.Any()))
            {
                return false;
            }

            var userLectureDB = new LectureUser()
            {
                Id = simpleUser.Id,
                LectureId = lectureDto.Id,

            };

            _context.LectureUsers.Add(userLectureDB);
            _context.SaveChanges();

            return true;
        }

        public List<LectureUserDto> GetLectureUser()
        {
            var tmp = _context.LectureUsers.Select(x => x);

            if (tmp == null)
            {
                return null;
            }

            List<LectureUserDto> lectureUserDtos = new List<LectureUserDto>();

            foreach (var item in tmp)
            {
                lectureUserDtos.Add(new LectureUserDto()
                {
                    Id = item.Id,
                    LectureId = item.LectureId,
                    UserId = item.UserId,

                });
            }
            return lectureUserDtos;
        }
    }
}
