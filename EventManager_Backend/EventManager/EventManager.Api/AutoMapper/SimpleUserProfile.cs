using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using EventManager.Api.ViewModels;

namespace EventManager.Api.AutoMapper
{
    public class SimpleUserProfile : Profile
    {
        public SimpleUserProfile()
        {
            CreateMap<CreateEventViewModel, SimpleUserDto>();
            CreateMap<SimpleUserDto, CreateEventViewModel>();
            CreateMap<SimpleUserDto, SimpleUser>();
        }
    }
}
