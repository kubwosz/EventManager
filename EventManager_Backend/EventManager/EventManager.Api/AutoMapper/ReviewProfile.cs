using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using EventManager.Api.ViewModels;

namespace EventManager.Api.AutoMapper
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewViewModel, ReviewDto>();
            CreateMap<UpdateReviewViewModel, ReviewDto>();
            CreateMap<ReviewDto, CreateReviewViewModel>();
            CreateMap<ReviewDto, UpdateReviewViewModel>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewDto, ReviewViewModel>();
        }
    }
}
