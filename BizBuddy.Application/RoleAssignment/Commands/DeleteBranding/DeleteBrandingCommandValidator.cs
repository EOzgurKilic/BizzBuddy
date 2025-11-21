using System;
using FluentValidation;

namespace BizBuddy.Application.RoleAssignment.Commands.DeleteBranding;


public class DeleteBrandingCommandValidator : AbstractValidator<DeleteBrandingCommand>
{
    public DeleteBrandingCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
