using EventManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Domain.IServices
{
    public interface ILectureService
    {
        LectureDto AddLecture(LectureDto addLectureDto);
        List<LectureDto> GetAll();
        LectureDto UpdateLecture(LectureDto updateLectureDto);
        LectureDto GetOne(int id);
        bool Delete(int id);
    }
}
