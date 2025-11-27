using FluentValidation;

namespace BizBuddy.Application.Products.Commands.UpdateProducts;

public class UpdateProductsCommandValidator : AbstractValidator<UpdateProductsCommand>
{
    public UpdateProductsCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name cannot exceed 200 characters");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId must be greater than 0");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");

        RuleFor(x => x.StockQty)
            .GreaterThanOrEqualTo(0).When(x => x.StockQty.HasValue)
            .WithMessage("StockQty cannot be negative");

        RuleFor(x => x.Unit)
            .MaximumLength(50).When(x => !string.IsNullOrWhiteSpace(x.Unit))
            .WithMessage("Unit cannot exceed 50 characters");
    }
}
