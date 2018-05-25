using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using EventManager.Api.ViewModels;

namespace EventManager.Api.AutoMapper
{
    public class LectureProfile : Profile
    {
        public LectureProfile()
        {
            CreateMap<CreateLectureViewModel, LectureDto>();
            CreateMap<UpdateLectureViewModel, LectureDto>();
            CreateMap<LectureDto, CreateLectureViewModel>();
            CreateMap<LectureDto, UpdateLectureViewModel>();
            CreateMap<LectureDto, Lecture>();
            CreateMap<LectureDto, LectureViewModel>();
        }
    }
}
