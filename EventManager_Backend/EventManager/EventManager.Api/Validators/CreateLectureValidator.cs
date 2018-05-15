using EventManager.Api.ViewModels;
using FluentValidation;

namespace EventManager.Api.Validators
{
    public class CreateLectureValidator : AbstractValidator<CreateLectureViewModel>
    {
        CreateLectureValidator()
        {
            RuleFor(lecture => lecture.EventId)
                .NotEmpty();
            RuleFor(lecture => lecture.Name)
                .MinimumLength(3);
            RuleFor(lecture => lecture.StartDate)
                .NotEmpty();
            RuleFor(lecture => lecture.EndDate)
                .NotEmpty();
        }
    }
}
