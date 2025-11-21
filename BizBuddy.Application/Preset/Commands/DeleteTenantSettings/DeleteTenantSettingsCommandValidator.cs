using System;
using FluentValidation;

namespace BizBuddy.Application.Preset.Commands.DeleteTenantSettings;

public class DeleteTenantSettingsCommandValidator : AbstractValidator<DeleteTenantSettingsCommand>
{
    public DeleteTenantSettingsCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
