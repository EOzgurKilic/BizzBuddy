using System;
using FluentValidation;

namespace BizBuddy.Application.Orders.Commands.DeletePayment;

public class DeletePaymentCommandValidator : AbstractValidator<DeletePaymentCommand>
{
    public DeletePaymentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
