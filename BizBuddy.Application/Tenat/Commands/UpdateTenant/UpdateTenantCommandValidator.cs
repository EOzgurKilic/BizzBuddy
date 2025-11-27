using FluentValidation;

namespace BizBuddy.Application.Tenat.Commands.UpdateTenant;

public class UpdateTenantCommandValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdateTenantCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tenant name is required")
            .MaximumLength(200).WithMessage("Tenant name cannot exceed 200 characters");

        RuleFor(x => x.PresetName)
            .MaximumLength(100).WithMessage("PresetName cannot exceed 100 characters")
            .When(x => !string.IsNullOrWhiteSpace(x.PresetName));
    }
}
