using FluentValidation;

namespace BizBuddy.Application.Products.Commands.CreateProducts
{
    public class CreateProductsCommandValidator : AbstractValidator<CreateProductsCommand>
    {
        public CreateProductsCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name is required.")
                .MinimumLength(2)
                .WithMessage("Product name must contain at least 2 characters.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("CategoryId must be greater than 0.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price cannot be negative.");

            RuleFor(x => x.StockQty)
                .GreaterThanOrEqualTo(0)
                .When(x => x.StockQty.HasValue)
                .WithMessage("Stock quantity cannot be negative.");

            RuleFor(x => x.Unit)
                .MaximumLength(50)
                .When(x => !string.IsNullOrWhiteSpace(x.Unit))
                .WithMessage("Unit cannot exceed 50 characters.");
        }
    }
}
