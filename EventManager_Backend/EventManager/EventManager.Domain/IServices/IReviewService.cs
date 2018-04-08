using EventManager.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Domain.IServices
{
    public interface IReviewService
    {
        ReviewDto CreateReview(CreateReviewDto addReviewDto);
        ReviewDto UpdateReview(UpdateReviewDto updateReviewDto);
        List<ReviewDto> GetAll();
        bool DeleteReview(int id);
    }
}
