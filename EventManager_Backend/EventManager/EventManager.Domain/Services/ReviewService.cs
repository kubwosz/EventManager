using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.IServices;
using EventManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManager.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly EventManagerContext _context;
        private readonly IMapper _iMapper;

        public ReviewService(IMapper iMapper)
        {
            _context = new EventManagerContext();
            _iMapper = iMapper;
        }

        public ReviewDto CreateReview(CreateReviewDto addReviewDto)
        {
            if (!(_context.SimpleUsers.Any(x => x.Id == addReviewDto.ReviewerId) && _context.Lectures.Any(x=> x.Id == addReviewDto.LectureId)))
            {
                return null;
            }

            var review = _iMapper.Map<Review>(addReviewDto);

            _context.Reviews.Add(review);
            _context.SaveChanges();

            var reviewDto = _iMapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public ReviewDto UpdateReview(UpdateReviewDto updateReviewDto)
        {
            var review = _iMapper.Map<Review>(updateReviewDto);

            _context.Reviews.Update(review);
            _context.SaveChanges();

            var reviewDto = _iMapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public List<ReviewDto> GetAll()
        {
            var reviews = _context.Reviews;

            if (reviews == null)
                return null;

            List<ReviewDto> reviewDtoList = _iMapper.Map<List<ReviewDto>>(reviews);

            return reviewDtoList;
        }

        public bool DeleteReview(int id)
        {
            var review = _context.Reviews.SingleOrDefault(x => x.Id == id);

            if(review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            return _context.SaveChanges() > 0;
        }
    }
}
