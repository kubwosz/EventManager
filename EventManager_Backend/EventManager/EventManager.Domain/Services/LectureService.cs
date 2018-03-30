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
            var lectures = _context.Lectures.Select(x => x);

            List<LectureDto> lectureDtosList = new List<LectureDto>();

            foreach (var item in lectures)
            {
                lectureDtosList.Add(new LectureDto()
                {
                    Id = item.Id,
                    EventId = item.EventId,
                    Description = item.Description,
                    Name = item.Name,
                    ParticipantNumber = item.ParticipantNumber,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate
                });
            }
            return lectureDtosList;
        }
    }
}