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
                .MinimumLength(3);
            RuleFor(@event => @event.StartDate)
                .NotEmpty();
            RuleFor(@event => @event.EndDate)
                .NotEmpty();
            RuleFor(@event => @event.ParticipantNumber)
                .GreaterThan(0);
        }
    }
}
