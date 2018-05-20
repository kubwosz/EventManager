using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;


namespace EventManager.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly EventManagerContext _context;

        public ReviewService(EventManagerContext context)
        {
            _context = context;
        }

        public ReviewDto CreateReview(ReviewDto reviewDto)
        {
            if (!(_context.SimpleUsers.Any(x => x.Id == reviewDto.ReviewerId) && _context.Lectures.Any(x=> x.Id == reviewDto.LectureId)))
            {
                return null;
            }

            var review = Mapper.Map<Review>(reviewDto);

            _context.Reviews.Add(review);
            _context.SaveChanges();

            reviewDto = Mapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public ReviewDto UpdateReview(ReviewDto reviewDto)
        {
            var review = Mapper.Map<Review>(reviewDto);

            _context.Reviews.Update(review);
            _context.SaveChanges();

            reviewDto = Mapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public List<ReviewDto> GetAll()
        {
            var reviews = _context.Reviews;

            if (reviews == null)
                return null;

            List<ReviewDto> reviewDtoList = Mapper.Map<List<ReviewDto>>(reviews);

            return reviewDtoList;
        }

        public ReviewDto GetReviewById(int id)
        {
            var review = _context.Reviews.FirstOrDefault(x => x.Id == id);

            if(review == null)
            {
                return null;
            }

            ReviewDto reviewDto = Mapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public bool DeleteReview(int id)
        {
            var review = _context.Reviews.SingleOrDefault(x => x.Id == id);

            if(review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            var result = _context.SaveChanges();
            
            return result > 0;
        }
    }
}
