using FluentValidation;

namespace BizBuddy.Application.Preset.Commands.CreateTenantSettings
{
    public class CreateTenantSettingsValidator : AbstractValidator<CreateTenantSettingsCommand>
    {
        public CreateTenantSettingsValidator()
        {
            RuleFor(x => x.EnabledModules)
                .NotEmpty()
                .WithMessage("EnabledModules cannot be empty.");

            RuleFor(x => x.MenuOrder)
                .NotEmpty()
                .WithMessage("MenuOrder cannot be empty.");

            RuleFor(x => x.BrandingId)
                .GreaterThan(0)
                .WithMessage("BrandingId must be greater than 0.");
        }
    }
}
