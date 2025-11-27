using FluentValidation;

namespace BizBuddy.Application.Preset.Commands.UpdatePreset;

public class UpdatePresetCommandValidator : AbstractValidator<UpdatePresetCommand>
{
    public UpdatePresetCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0");

        RuleFor(x => x.EnabledModules)
            .NotNull()
            .WithMessage("EnabledModules cannot be null");

        RuleForEach(x => x.EnabledModules)
            .NotEmpty()
            .WithMessage("EnabledModules cannot contain empty values");

        RuleFor(x => x.MenuOrder)
            .NotNull()
            .WithMessage("MenuOrder cannot be null");

        RuleForEach(x => x.MenuOrder)
            .NotEmpty()
            .WithMessage("MenuOrder cannot contain empty values");

        RuleFor(x => x.Notes)
            .MaximumLength(500)
            .When(x => !string.IsNullOrEmpty(x.Notes))
            .WithMessage("Notes cannot exceed 500 characters");

        RuleFor(x => x.EnabledModulesJson)
            .MaximumLength(4000)
            .When(x => !string.IsNullOrEmpty(x.EnabledModulesJson))
            .WithMessage("EnabledModulesJson cannot exceed 4000 characters");

        RuleFor(x => x.MenuOrderJson)
            .MaximumLength(4000)
            .When(x => !string.IsNullOrEmpty(x.MenuOrderJson))
            .WithMessage("MenuOrderJson cannot exceed 4000 characters");

        RuleFor(x => x.DefaultFieldsJson)
            .MaximumLength(4000)
            .When(x => !string.IsNullOrEmpty(x.DefaultFieldsJson))
            .WithMessage("DefaultFieldsJson cannot exceed 4000 characters");
    }
}
