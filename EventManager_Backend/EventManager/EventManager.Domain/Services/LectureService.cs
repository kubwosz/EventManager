using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManager.Domain.Services
{
    public class LectureService
    {
        private readonly EventManagerContext _context;

        public LectureService()
        {
            _context = new EventManagerContext();
        }

        public LectureDto AddLecture(AddLectureDto addLectureDto)
        {
            if (!_context.Events.Any(x => x.Id == addLectureDto.EventId))
                return null;

            var lecture = new Lecture()
            {
                EventId = addLectureDto.EventId,
                Description = addLectureDto.Description,
                Name = addLectureDto.Name,
                ParticipantNumber = addLectureDto.ParticipantNumber,
                StartDate = addLectureDto.StartDate,
                EndDate = addLectureDto.EndDate
            };

            _context.Lectures.Add(lecture);
            _context.SaveChanges();

            var lectureDto = new LectureDto()
            {
                Id = lecture.Id,
                EventId = lecture.EventId,
                Description = lecture.Description,
                Name = lecture.Name,
                ParticipantNumber = lecture.ParticipantNumber,
                StartDate = lecture.StartDate,
                EndDate = lecture.EndDate
            };
            return lectureDto;
        }

        public List<LectureDto> GetAll()
        {
            var lecturesList = _context.Lectures.Select(x => x);

            List<LectureDto> lectureDtos = new List<LectureDto>();

            foreach (var lecture in lecturesList)
            {
                lectureDtos.Add(new LectureDto()
                {
                    Id = lecture.Id,
                    EventId = lecture.EventId,
                    Description = lecture.Description,
                    Name = lecture.Name,
                    ParticipantNumber = lecture.ParticipantNumber,
                    StartDate = lecture.StartDate,
                    EndDate = lecture.EndDate
                });
            }
            return lectureDtos;
        }
    }
}