using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
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
            CreateMap<EventDto, Event>();
            CreateMap<EventDto, Event>();
            CreateMap<Event, EventDto>();

            CreateMap<LectureDto, Lecture>();
            CreateMap<LectureDto, Lecture>();
            CreateMap<Lecture, LectureDto>();

            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
        }
    }
}
