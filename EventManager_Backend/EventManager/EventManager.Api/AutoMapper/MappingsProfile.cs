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
            CreateMap<CreateEventDto, Event>();
            CreateMap<Event, EventDto>();
            CreateMap<AddLectureDto, Lecture>();
            CreateMap<Lecture, LectureDto>();
            CreateMap<CreateReviewDto, Review>();
        }
    }
}
