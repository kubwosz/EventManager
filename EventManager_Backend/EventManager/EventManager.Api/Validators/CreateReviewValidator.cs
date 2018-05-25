using EventManager.Api.ViewModels;
using FluentValidation;

namespace EventManager.Api.Validators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewViewModel>
    {
        public CreateReviewValidator()
        {
            RuleFor(review => review.LectureId)
                    .NotEmpty();
            RuleFor(review => review.Comment)
                    .NotNull()
                    .Length(3,1000);
            RuleFor(review => review.Nickname)
                    .NotNull()
                    .Length(3,70);
            RuleFor(review => review.Rate)
                    .NotEmpty()
                    .InclusiveBetween(0,10);
            RuleFor(review => review.ReviewerId)
                    .NotEmpty();
        }
    }
}
