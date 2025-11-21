using System;
using FluentValidation;

namespace BizBuddy.Application.InventoryMoves.Commands.CreateInventoryMoves;


public class CreateInventoryMovesValidator : AbstractValidator<CreateInventoryMovesCommand>
{
    public CreateInventoryMovesValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId must be greater than 0.");

        RuleFor(x => x.Qty)
            .NotEqual(0).WithMessage("Qty (amount) can't equal 0.")
            .Must(q => q > -1_000_000 && q < 1_000_000)
            .WithMessage("Qty must be in the range of -1000000 to 1000000.");

        RuleFor(x => x.Reason)
            .MaximumLength(250)
            .WithMessage("Reason can't be longer than 250 characters.");

        RuleFor(x => x.RefType)
            .Must(x => string.IsNullOrEmpty(x) || 
                new[] { "order", "appointment", "manual", "purchase", "adjustment" }
                .Contains(x.ToLower()))
            .WithMessage("RefType must be one of the following valid options; order, appointment, manual, purchase, adjustment.");

       


    }
}

