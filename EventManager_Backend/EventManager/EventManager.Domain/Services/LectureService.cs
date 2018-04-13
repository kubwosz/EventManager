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
    public class LectureService : ILectureService
    {
        private readonly EventManagerContext _context;
        private readonly IMapper _iMapper;

        public LectureService(IMapper iMapper)
        {
            _context = new EventManagerContext();
            _iMapper = iMapper;
        }

        public LectureDto AddLecture(LectureDto lectureDto)
        {
            if (!_context.Events.Any(x => x.Id == lectureDto.EventId))
                return null;

            var lecture = _iMapper.Map<Lecture>(lectureDto);

            _context.Lectures.Add(lecture);
            _context.SaveChanges();

            lectureDto = _iMapper.Map<LectureDto>(lecture);

            return lectureDto;
        }

        public List<LectureDto> GetAll()
        {
            var lectures = _context.Lectures;

            if (lectures == null)
                return null;

            List<LectureDto> lectureDtoList = _iMapper.Map<List<LectureDto>>(lectures);

            return lectureDtoList;
        }

        public LectureDto GetOne(int id)
        {
            var lecture = _context.Lectures.FirstOrDefault(x => x.Id == id);

            if (lecture == null)
            {
                return null;
            }

            LectureDto lectureDto = _iMapper.Map<LectureDto>(lecture);

            return lectureDto;
        }

        public LectureDto UpdateLecture(LectureDto lectureDto)
        {
            var lecture = _iMapper.Map<Lecture>(lectureDto);

            _context.Lectures.Update(lecture);
            _context.SaveChanges();

            lectureDto = _iMapper.Map<LectureDto>(lecture);

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