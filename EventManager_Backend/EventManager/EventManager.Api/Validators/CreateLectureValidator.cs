using EventManager.Api.ViewModels;
using FluentValidation;

namespace EventManager.Api.Validators
{
    public class CreateLectureValidator : AbstractValidator<CreateLectureViewModel>
    {
        public CreateLectureValidator()
        {
            RuleFor(lecture => lecture.EventId)
                .NotEmpty();
            RuleFor(lecture => lecture.Name)
                .NotNull()
                .Length(3,70);
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
