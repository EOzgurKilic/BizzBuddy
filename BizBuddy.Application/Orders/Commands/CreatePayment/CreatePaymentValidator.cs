using FluentValidation;
using System;

namespace BizBuddy.Application.Orders.Commands.CreatePayment
{
    public class CreatePaymentValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0)
                .WithMessage("OrderId must be greater than 0.");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Payment amount must be greater than 0.");

            RuleFor(x => x.Method)
                .NotEmpty()
                .WithMessage("Payment method is required.");

            RuleFor(x => x.ProviderRef)
                .MaximumLength(200)
                .When(x => !string.IsNullOrWhiteSpace(x.ProviderRef))
                .WithMessage("Provider reference cannot exceed 200 characters.");

            RuleFor(x => x.Notes)
                .MaximumLength(500)
                .When(x => !string.IsNullOrWhiteSpace(x.Notes))
                .WithMessage("Notes cannot exceed 500 characters.");
        }
    }
}
