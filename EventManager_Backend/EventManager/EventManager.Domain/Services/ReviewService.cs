using EventManager.Domain.Dtos;
using EventManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManager.Domain.Services
{
    class ReviewService
    {
        private readonly EventManagerContext _context;

        public ReviewService()
        {
            _context = new EventManagerContext();
        }

        public ReviewDto CreateReview(CreateReviewDto addReviewDto)
        {
            if (!(_context.SimpleUsers.Any(x => x.Id == addReviewDto.ReviewerId) && _context.SimpleUsers.Any(x=> x.Id == addReviewDto.LectureId)))
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
    }
}
