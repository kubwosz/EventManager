using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using EventManager.Api.ViewModels;

namespace EventManager.Api.AutoMapper
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventViewModel, EventDto>();
            CreateMap<UpdateEventViewModel, EventDto>();
            CreateMap<EventDto, CreateEventViewModel>();
            CreateMap<EventDto, UpdateEventViewModel>();
            CreateMap<EventDto, Event>();
            CreateMap<EventDto, EventViewModel>();
        }
    }
}
