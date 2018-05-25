using EventManager.Api.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Validators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewViewModel>
    {
        public UpdateReviewValidator()
        {
            RuleFor(review => review.Id)
                    .NotEmpty();
            RuleFor(review => review.LectureId)
                    .NotEmpty();
            RuleFor(review => review.Comment)
                    .NotNull()
                    .Length(3, 1000);
            RuleFor(review => review.Nickname)
                    .NotNull()
                    .Length(3, 70);
            RuleFor(review => review.Rate)
                    .NotEmpty()
                    .InclusiveBetween(0, 10);
            RuleFor(review => review.ReviewerId)
                    .NotEmpty();
        }
    }
}
