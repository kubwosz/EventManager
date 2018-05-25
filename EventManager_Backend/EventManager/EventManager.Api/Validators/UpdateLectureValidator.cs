using EventManager.Api.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Validators
{
    public class UpdateLectureValidator : AbstractValidator<UpdateLectureViewModel>
    {
        public UpdateLectureValidator()
        {
            RuleFor(review => review.Id)
                .NotEmpty();
            RuleFor(lecture => lecture.EventId)
                .NotEmpty();
            RuleFor(lecture => lecture.Name)
                .NotNull()
                .Length(3, 70);
            RuleFor(lecture => lecture.StartDate)
                .NotEmpty();
            RuleFor(lecture => lecture.EndDate)
                .NotEmpty();
            RuleFor(lecture => lecture.ParticipantNumber)
                .GreaterThan(0);
            RuleFor(lecture => lecture.Description)
                .MaximumLength(1000);
        }
    }
}
