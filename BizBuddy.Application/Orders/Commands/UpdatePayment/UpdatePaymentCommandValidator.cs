using FluentValidation;

namespace BizBuddy.Application.Orders.Commands.UpdatePayment;

public class UpdatePaymentCommandValidator : AbstractValidator<UpdatePaymentCommand>
{
    public UpdatePaymentCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Payment Id must be greater than 0");

        RuleFor(x => x.OrderId)
            .GreaterThan(0).WithMessage("OrderId is required");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0");

        RuleFor(x => x.Method)
            .NotEmpty().WithMessage("Payment Method is required")
            .MaximumLength(100).WithMessage("Payment Method cannot exceed 100 characters");

        RuleFor(x => x.ProviderRef)
            .MaximumLength(200).WithMessage("Provider Reference cannot exceed 200 characters");

        RuleFor(x => x.PaidAt)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("PaidAt cannot be in the future");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes cannot exceed 500 characters");
    }
}
