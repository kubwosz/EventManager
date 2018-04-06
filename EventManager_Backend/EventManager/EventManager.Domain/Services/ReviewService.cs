using AutoMapper;
using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManager.Domain.Services
{
    public class ReviewService
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
            var review = _context.Reviews.FirstOrDefault(x => x.Id == updateReviewDto.Id);

            if (review == null)
                return null;

            review.LectureId = updateReviewDto.LectureId;
            review.ReviewerId = updateReviewDto.ReviewerId;
            review.Rate = updateReviewDto.Rate;
            review.Nickname = updateReviewDto.Nickname;
            review.Comment = updateReviewDto.Comment;

            _context.Reviews.Update(review);
            _context.SaveChanges();

            var reviewDto = _iMapper.Map<ReviewDto>(review);

            return reviewDto;
        }

        public List<ReviewDto> GetAll()
        {
            var reviews = _context.Reviews.Select(x => x);

            if (reviews == null)
                return null;

            List<ReviewDto> reviewDtoList = _iMapper.Map<List<ReviewDto>>(reviews);

            return reviewDtoList;
        }

        public bool DeleteReview(int id)
        {
            var review = _context.Reviews.FirstOrDefault(x => x.Id == id);

            if(review == null)
            {
                return false;
            }

            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return true;
        }
    }
}
