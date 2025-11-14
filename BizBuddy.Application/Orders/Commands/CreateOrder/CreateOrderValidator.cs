using FluentValidation;

namespace BizBuddy.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("CustomerId must be greater than 0.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.");

            RuleFor(x => x.Subtotal)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Subtotal cannot be negative.");

            RuleFor(x => x.Total)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Total cannot be negative.");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("Order must contain at least one item.");

            RuleFor(x => x.Payments)
                .NotEmpty()
                .WithMessage("Order must contain at least one payment.");
        }
    }
}
