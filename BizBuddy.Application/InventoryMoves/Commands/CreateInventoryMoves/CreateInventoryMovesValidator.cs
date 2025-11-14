using System;
using FluentValidation;

namespace BizBuddy.Application.InventoryMoves.Commands.CreateInventoryMoves;


public class CreateInventoryMovesValidator : AbstractValidator<CreateInventoryMovesCommand>
{
    public CreateInventoryMovesValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0)
            .WithMessage("ProductId sıfırdan büyük olmalıdır.");

        RuleFor(x => x.Qty)
            .NotEqual(0).WithMessage("Qty (miktar) sıfır olamaz.")
            .Must(q => q > -1_000_000 && q < 1_000_000)
            .WithMessage("Qty çok büyük veya çok küçük bir değer olamaz.");

        RuleFor(x => x.Reason)
            .MaximumLength(250)
            .WithMessage("Reason 250 karakterden uzun olamaz.");

        RuleFor(x => x.RefType)
            .Must(x => string.IsNullOrEmpty(x) || 
                new[] { "order", "appointment", "manual", "purchase", "adjustment" }
                .Contains(x.ToLower()))
            .WithMessage("RefType geçerli bir değer olmalıdır: order, appointment, manual, purchase, adjustment.");

       


    }
}

