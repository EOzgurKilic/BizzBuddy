using FluentValidation;

namespace BizBuddy.Application.Orders.Commands.UpdateAppointment;

public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
{
    public UpdateAppointmentCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("CustomerId is required.");

        RuleFor(x => x.Start)
            .NotEmpty().WithMessage("Start date is required.");

        RuleFor(x => x.End)
            .NotEmpty().WithMessage("End date is required.");

        RuleFor(x => x)
            .Must(x => x.Start < x.End)
            .WithMessage("Start date must be earlier than End date.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.")
            .MaximumLength(100);

        RuleFor(x => x.Notes)
            .MaximumLength(1000)
            .When(x => !string.IsNullOrWhiteSpace(x.Notes));

        RuleFor(x => x.Custom)
            .MaximumLength(2000)
            .When(x => !string.IsNullOrWhiteSpace(x.Custom));
    }
}
