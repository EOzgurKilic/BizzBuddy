using System;
using FluentValidation;

namespace BizBuddy.Application.InventoryMoves.Commands.DeleteInventoryMoves;

public class DeleteInventoryMovesCommandValidator : AbstractValidator<DeleteInventoryMovesCommand>
{
    public DeleteInventoryMovesCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
