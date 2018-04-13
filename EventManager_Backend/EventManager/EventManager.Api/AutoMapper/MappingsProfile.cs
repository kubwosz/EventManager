using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using EventManager.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.AutoMapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<CreateEventViewModel, EventDto>();
            CreateMap<UpdateEventViewModel, EventDto>();
            CreateMap<EventDto, CreateEventViewModel>();
            CreateMap<EventDto, UpdateEventViewModel>();
            CreateMap<EventDto, Event>();

            CreateMap<CreateLectureViewModel, LectureDto>();
            CreateMap<UpdateLectureViewModel, LectureDto>();
            CreateMap<LectureDto, CreateLectureViewModel>();
            CreateMap<LectureDto, UpdateLectureViewModel>();
            CreateMap<LectureDto, Lecture>();

            CreateMap<CreateReviewViewModel, ReviewDto>();
            CreateMap<UpdateReviewViewModel, ReviewDto>();
            CreateMap<ReviewDto, CreateReviewViewModel>();
            CreateMap<ReviewDto, UpdateReviewViewModel>();
            CreateMap<ReviewDto, Review>();
        }
    }
}
