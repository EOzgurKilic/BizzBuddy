using System;
using FluentValidation;

namespace BizBuddy.Application.Orders.Commands.DeleteOrderItem;


public class DeleteOrderItemCommandValidator : AbstractValidator<DeleteOrderItemCommand>
{
    public DeleteOrderItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
