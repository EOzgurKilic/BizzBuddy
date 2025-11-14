using FluentValidation;

namespace BizBuddy.Application.Orders.Commands.CreateOrderItem
{
    public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemCommand>
    {
        public CreateOrderItemValidator()
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0)
                .WithMessage("OrderId must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0)
                .WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.Qty)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.UnitPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Unit price cannot be negative.");

            RuleFor(x => x.Notes)
                .MaximumLength(500)
                .When(x => !string.IsNullOrWhiteSpace(x.Notes))
                .WithMessage("Notes cannot exceed 500 characters.");

            RuleFor(x => x.Custom)
                .MaximumLength(500)
                .When(x => !string.IsNullOrWhiteSpace(x.Custom))
                .WithMessage("Custom field cannot exceed 500 characters.");
        }
    }
}
