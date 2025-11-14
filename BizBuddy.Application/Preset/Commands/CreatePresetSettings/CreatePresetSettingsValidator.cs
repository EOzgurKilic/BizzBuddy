using FluentValidation;

namespace BizBuddy.Application.Preset.Commands
{
    public class CreatePresetSettingsValidator : AbstractValidator<CreatePresetSettingsCommand>
    {
        public CreatePresetSettingsValidator()
        {
            RuleFor(x => x.EnabledModules)
                .NotEmpty()
                .WithMessage("EnabledModules cannot be empty.");

            RuleFor(x => x.MenuOrder)
                .NotEmpty()
                .WithMessage("MenuOrder cannot be empty.");

            RuleFor(x => x.Notes)
                .MaximumLength(500)
                .When(x => !string.IsNullOrWhiteSpace(x.Notes))
                .WithMessage("Notes cannot exceed 500 characters.");

            RuleFor(x => x.EnabledModulesJson)
                .MaximumLength(4000)
                .When(x => !string.IsNullOrWhiteSpace(x.EnabledModulesJson))
                .WithMessage("EnabledModulesJson cannot exceed 4000 characters.");

            RuleFor(x => x.MenuOrderJson)
                .MaximumLength(4000)
                .When(x => !string.IsNullOrWhiteSpace(x.MenuOrderJson))
                .WithMessage("MenuOrderJson cannot exceed 4000 characters.");

            RuleFor(x => x.DefaultFieldsJson)
                .MaximumLength(4000)
                .When(x => !string.IsNullOrWhiteSpace(x.DefaultFieldsJson))
                .WithMessage("DefaultFieldsJson cannot exceed 4000 characters.");
        }
    }
}
