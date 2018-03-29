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

        public ReviewDto CreateService(CreateReviewDto addReviewDto)
        {
            if (!_context.SimpleUsers.Any(x => x.Id == addReviewDto.ReviewerId))
            {
                return null;
            }

            var review = new Review()
            {

            };

            _context.Reviews.Add(review);
            _context.SaveChanges();

            var reviewDto = new ReviewDto()
            {
            };

            return reviewDto;
        }
    }
}
