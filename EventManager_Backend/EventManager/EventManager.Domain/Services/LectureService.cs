using AutoMapper;
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
        private readonly IMapper _iMapper;

        public LectureService(IMapper iMapper)
        {
            _context = new EventManagerContext();
            _iMapper = iMapper;
        }

        public LectureDto AddLecture(AddLectureDto addLectureDto)
        {
            if (!_context.Events.Any(x => x.Id == addLectureDto.EventId))
                return null;

            var lecture = _iMapper.Map<Lecture>(addLectureDto);

            _context.Lectures.Add(lecture);
            _context.SaveChanges();

            var lectureDto = _iMapper.Map<LectureDto>(lecture);

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

        public LectureDto UpdateLecture(UpdateLectureDto updateLectureDto)
        {
            var lecture = _iMapper.Map<Lecture>(updateLectureDto);

            _context.Lectures.Update(lecture);
            _context.SaveChanges();

            var lectureDto = _iMapper.Map<LectureDto>(lecture);

            return lectureDto;
        }
      
        public bool Delete(int id)
        {
            var result = _context.Lectures.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return false;

            _context.Lectures.Remove(result);
            _context.SaveChanges();
            return true;
        }
    }
}