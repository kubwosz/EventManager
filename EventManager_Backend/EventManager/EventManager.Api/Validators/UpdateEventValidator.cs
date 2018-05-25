using EventManager.Api.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManager.Api.Validators
{
    public class UpdateEventValidator : AbstractValidator<UpdateEventViewModel>
    {
        public UpdateEventValidator()
        {
            RuleFor(@event => @event.Id)
                .NotEmpty();
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
