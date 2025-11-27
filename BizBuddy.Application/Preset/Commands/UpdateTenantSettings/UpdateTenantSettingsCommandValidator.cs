using FluentValidation;

namespace BizBuddy.Application.Preset.Commands.UpdateTenantSettings;

public class UpdateTenantSettingsCommandValidator : AbstractValidator<UpdateTenantSettingsCommand>
{
    public UpdateTenantSettingsCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");

        RuleFor(x => x.BrandingId)
            .GreaterThan(0).WithMessage("BrandingId must be greater than 0");

        RuleFor(x => x.EnabledModules)
            .NotNull().WithMessage("EnabledModules cannot be null");

        RuleForEach(x => x.EnabledModules)
            .NotEmpty().WithMessage("EnabledModules cannot contain empty values");

        RuleFor(x => x.MenuOrder)
            .NotNull().WithMessage("MenuOrder cannot be null");

        RuleForEach(x => x.MenuOrder)
            .NotEmpty().WithMessage("MenuOrder cannot contain empty values");
    }
}
