using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace EventManager.Domain.Services
{
    public class LectureService : ILectureService
    {
        private readonly EventManagerContext _context;

        public LectureService(EventManagerContext context)
        {
            _context = context;
        }

        public LectureDto AddLecture(LectureDto lectureDto)
        {
            var @event = _context.Events.SingleOrDefault(x => x.Id == lectureDto.EventId);

            if (@event == null)
                return null;
            if ( (@event.StartDate.Ticks > lectureDto.StartDate.Ticks) 
                ||(@event.EndDate.Ticks < lectureDto.StartDate.Ticks) 
                || (@event.StartDate.Ticks > lectureDto.EndDate.Ticks) 
                || (@event.EndDate.Ticks < lectureDto.EndDate.Ticks))
                return null;

            var lecture = Mapper.Map<Lecture>(lectureDto);

            _context.Lectures.Add(lecture);
            _context.SaveChanges();

            lectureDto = Mapper.Map<LectureDto>(lecture);

            return lectureDto;
        }

        public List<LectureDto> GetAll()
        {
            var lectures = _context.Lectures;

            if (lectures == null)
                return null;

            List<LectureDto> lectureDtoList = Mapper.Map<List<LectureDto>>(lectures);

            return lectureDtoList;
        }

        public LectureDto GetLectureById(int id)
        {
            var lecture = _context.Lectures.FirstOrDefault(x => x.Id == id);

            if (lecture == null)
            {
                return null;
            }

            var @event = _context.Events.SingleOrDefault(x => x.Id == lecture.EventId);

            LectureDto lectureDto = Mapper.Map<LectureDto>(lecture);

            if ((@event.StartDate.Ticks <= lecture.StartDate.Ticks)
                || (@event.EndDate.Ticks >= lecture.StartDate.Ticks)
                || (@event.StartDate.Ticks < lecture.EndDate.Ticks)
                || (@event.EndDate.Ticks >= lecture.EndDate.Ticks))
                return null;

            return lectureDto;
        }

        public LectureDto UpdateLecture(LectureDto lectureDto)
        {
            var lecture = Mapper.Map<Lecture>(lectureDto);

            _context.Lectures.Update(lecture);
            _context.SaveChanges();

            lectureDto = Mapper.Map<LectureDto>(lecture);

            return lectureDto;
        }
      
        public bool Delete(int id)
        {
            var lecture = _context.Lectures.FirstOrDefault(x => x.Id == id);

            if (lecture == null)
                return false;

            _context.Lectures.Remove(lecture);
            var result = _context.SaveChanges();
            
            return result > 0;
        }
    }
}