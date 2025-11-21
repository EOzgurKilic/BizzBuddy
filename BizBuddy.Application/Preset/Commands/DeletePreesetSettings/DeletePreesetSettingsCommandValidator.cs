using System;
using FluentValidation;

namespace BizBuddy.Application.Preset.Commands.DeletePreesetSettings;

public class DeletePreesetSettingsCommandValidator : AbstractValidator<DeletePreesetSettingsCommand>
{
    public DeletePreesetSettingsCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
