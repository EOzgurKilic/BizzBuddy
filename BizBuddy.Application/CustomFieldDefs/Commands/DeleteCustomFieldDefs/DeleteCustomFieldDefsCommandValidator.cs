using System;
using FluentValidation;

namespace BizBuddy.Application.CustomFieldDefs.Commands.DeleteCustomFieldDefs;

public class DeleteCustomFieldDefsCommandValidator : AbstractValidator<DeleteCustomFieldDefsCommand>
{
    public DeleteCustomFieldDefsCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
