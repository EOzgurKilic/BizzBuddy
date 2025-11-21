using System;
using FluentValidation;

namespace BizBuddy.Application.Customers.Commands.DeleteCustomers;

public class DeleteCustomersCommandValidator : AbstractValidator<DeleteCustomersCommand>
{
    public DeleteCustomersCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
