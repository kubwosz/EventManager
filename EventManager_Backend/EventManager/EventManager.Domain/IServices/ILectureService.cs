using EventManager.Domain.Dtos;
using System.Collections.Generic;


namespace EventManager.Domain.IServices
{
    public interface ILectureService
    {
        LectureDto AddLecture(LectureDto addLectureDto);
        List<LectureDto> GetAll();
        LectureDto UpdateLecture(LectureDto updateLectureDto);
        LectureDto GetLectureById(int id);
        bool Delete(int id);
    }
}
