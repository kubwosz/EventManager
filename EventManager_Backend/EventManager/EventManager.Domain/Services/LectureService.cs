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

            var lectureToDb = new Lecture()
            {
                EventId = addLectureDto.EventId,
                Description = addLectureDto.Description,
                Name = addLectureDto.Name,
                ParticipantNumber = addLectureDto.ParticipantNumber,
                StartDate = addLectureDto.StartDate,
                EndDate = addLectureDto.EndDate
            };

            _context.Lectures.Add(lectureToDb);
            _context.SaveChanges();

            var lectureDto = new LectureDto()
            {
                Id = lectureToDb.Id,
                EventId = addLectureDto.EventId,
                Description = addLectureDto.Description,
                Name = addLectureDto.Name,
                ParticipantNumber = addLectureDto.ParticipantNumber,
                StartDate = addLectureDto.StartDate,
                EndDate = addLectureDto.EndDate
            };

            return lectureDto;
        }
    }
}