using FluentValidation;

namespace BizBuddy.Application.RoleAssignment.Commands.UpdateBranding;

public class UpdateBrandingCommandValidator : AbstractValidator<UpdateBrandingCommand>
{
    public UpdateBrandingCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0");

        RuleFor(x => x.BrandName)
            .NotEmpty().WithMessage("Brand name is required")
            .MaximumLength(150).WithMessage("Brand name cannot exceed 150 characters");

        RuleFor(x => x.LogoUrl)
            .MaximumLength(500).WithMessage("LogoUrl cannot exceed 500 characters")
            .Must(BeValidUrl).When(x => !string.IsNullOrWhiteSpace(x.LogoUrl))
            .WithMessage("LogoUrl is not a valid URL");

        RuleFor(x => x.FaviconUrl)
            .MaximumLength(500).WithMessage("FaviconUrl cannot exceed 500 characters")
            .Must(BeValidUrl).When(x => !string.IsNullOrWhiteSpace(x.FaviconUrl))
            .WithMessage("FaviconUrl is not a valid URL");

        RuleFor(x => x.Background)
            .MaximumLength(50);

        RuleFor(x => x.Surface)
            .MaximumLength(50);

        RuleFor(x => x.Shadow)
            .MaximumLength(50);

        RuleFor(x => x.FontFamily)
            .MaximumLength(100);

        // DarkMode Validasyonu
        When(x => x.DarkMode != null, () =>
        {
            RuleFor(x => x.DarkMode!.Background)
                .MaximumLength(50);

            RuleFor(x => x.DarkMode!.Surface)
                .MaximumLength(50);

            RuleFor(x => x.DarkMode!.Text)
                .MaximumLength(50);
        });
    }

    private bool BeValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}
