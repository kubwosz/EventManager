using EventManager.Domain.Dtos;
using System.Collections.Generic;


namespace EventManager.Domain.IServices
{
    public interface IReviewService
    {
        ReviewDto CreateReview(ReviewDto addReviewDto);
        ReviewDto UpdateReview(ReviewDto updateReviewDto);
        List<ReviewDto> GetAll();
        ReviewDto GetOne(int id);
        bool DeleteReview(int id);
    }
}
