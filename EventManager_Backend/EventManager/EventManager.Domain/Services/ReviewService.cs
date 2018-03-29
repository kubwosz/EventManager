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

        public ReviewService()
        {
            _context = new EventManagerContext();
        }

        public ReviewDto CreateReview(CreateReviewDto addReviewDto)
        {
            if (!(_context.SimpleUsers.Any(x => x.Id == addReviewDto.ReviewerId) && _context.Lectures.Any(x=> x.Id == addReviewDto.LectureId)))
            {
                return null;
            }

            var review = new Review()
            {
                LectureId = addReviewDto.LectureId,
                Comment = addReviewDto.Comment,
                Nickname = addReviewDto.Nickname,
                Rate  = addReviewDto.Rate,
                ReviewerId = addReviewDto.ReviewerId
            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            var reviewDto = new ReviewDto()
            {
                Id = review.Id,
                LectureId = review.LectureId,
                ReviewerId = review.ReviewerId,
                Rate = review.Rate,
                Nickname = review.Nickname,
                Comment = review.Comment
            };

            return reviewDto;
        }

        public ReviewDto UpdateReview(UpdateReviewDto updateReviewDto)
        {
            var todo = _context.Reviews.FirstOrDefault(x => x.Id == updateReviewDto.Id);

            if (todo == null)
            {
                return null;
            }

            todo.LectureId = updateReviewDto.LectureId;
            todo.ReviewerId = updateReviewDto.ReviewerId;
            todo.Rate = updateReviewDto.Rate;
            todo.Nickname = updateReviewDto.Nickname;
            todo.Comment = updateReviewDto.Comment;

            _context.Reviews.Update(todo);
            _context.SaveChanges();

            var reviewDto = new ReviewDto()
            {
                Id = todo.Id,
                LectureId = todo.LectureId,
                ReviewerId = todo.ReviewerId,
                Rate = todo.Rate,
                Nickname = todo.Nickname,
                Comment = todo.Comment
            };

            return reviewDto;
        }

        public List<ReviewDto> GetAll()
        {
            var result = _context.Reviews.Select(x => x);

            if (result == null)
            {
                return null;
            }

            List<ReviewDto> reviewDtos = new List<ReviewDto>();

            foreach (var item in result)
            {
                reviewDtos.Add(new ReviewDto()
                {
                    Id = item.Id,
                    LectureId = item.LectureId,
                    ReviewerId = item.ReviewerId,
                    Rate = item.Rate,
                    Nickname = item.Nickname,
                    Comment = item.Comment
                });
            }

            return reviewDtos;
        }
    }
}
