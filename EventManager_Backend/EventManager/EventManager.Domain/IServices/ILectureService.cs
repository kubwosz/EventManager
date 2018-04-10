using EventManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Domain.IServices
{
    public interface ILectureService
    {
        LectureDto AddLecture(AddLectureDto addLectureDto);
        List<LectureDto> GetAll();
        LectureDto UpdateLecture(UpdateLectureDto updateLectureDto);
        bool Delete(int id);
    }
}
