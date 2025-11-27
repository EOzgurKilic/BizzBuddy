using FluentValidation;

namespace BizBuddy.Application.InventoryMoves.Commands.UpdateInventoryMoves;

public class UpdateInventoryMovesCommandValidator : AbstractValidator<UpdateInventoryMovesCommand>
{
    public UpdateInventoryMovesCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId is required.");

        RuleFor(x => x.Qty)
            .NotEqual(0).WithMessage("Qty cannot be 0.")
            .Must(q => q > 0).WithMessage("Qty must be greater than 0.");

        RuleFor(x => x.Reason)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.Reason));

        // Eğer RefType doluysa RefId zorunlu
        When(x => !string.IsNullOrWhiteSpace(x.RefType), () =>
        {
            RuleFor(x => x.RefId)
                .NotNull().WithMessage("RefId is required when RefType is provided.");
        });

        // Eğer RefId doluysa RefType zorunlu
        When(x => x.RefId != null, () =>
        {
            RuleFor(x => x.RefType)
                .NotEmpty().WithMessage("RefType is required when RefId is provided.")
                .MaximumLength(100);
        });
    }
}
