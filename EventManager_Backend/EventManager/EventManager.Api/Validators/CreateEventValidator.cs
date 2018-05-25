using EventManager.Api.ViewModels;
using FluentValidation;

namespace EventManager.Api.Validators
{
    public class CreateEventValidator : AbstractValidator<CreateEventViewModel>
    {
        public CreateEventValidator()
        {
            RuleFor(@event => @event.OwnerId)
                .NotEmpty();
            RuleFor(@event => @event.Name)
                .NotNull()
                .Length(3, 70);
            RuleFor(@event => @event.StartDate)
                .NotEmpty();
            RuleFor(@event => @event.EndDate)
                .NotEmpty();
            RuleFor(@event => @event.ParticipantNumber)
                .GreaterThan(0);
            RuleFor(@event => @event.Description)
                .MaximumLength(1000);
        }
    }
}
