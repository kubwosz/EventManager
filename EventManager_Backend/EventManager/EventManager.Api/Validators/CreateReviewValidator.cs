using EventManager.Api.ViewModels;
using FluentValidation;

namespace EventManager.Api.Validators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewViewModel>
    {
        CreateReviewValidator()
        {
            RuleFor(review => review.LectureId)
                    .NotEmpty();
            RuleFor(review => review.Comment)
                    .MinimumLength(3);
            RuleFor(review => review.Nickname)
                    .MinimumLength(3);
            RuleFor(review => review.Rate)
                    .NotEmpty();
            RuleFor(review => review.ReviewerId)
                    .NotEmpty();
        }
    }
}
