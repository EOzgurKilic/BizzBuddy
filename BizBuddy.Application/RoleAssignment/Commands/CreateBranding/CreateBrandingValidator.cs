using FluentValidation;

namespace BizBuddy.Application.RoleAssignment.Commands.CreateBranding
{
    public class CreateBrandingValidator : AbstractValidator<CreateBrandingCommand>
    {
        public CreateBrandingValidator()
        {
            RuleFor(x => x.BrandName)
                .NotEmpty()
                .WithMessage("BrandName is required.")
                .MinimumLength(2)
                .WithMessage("BrandName must be at least 2 characters.");

            RuleFor(x => x.LogoUrl)
                .MaximumLength(200)
                .When(x => !string.IsNullOrWhiteSpace(x.LogoUrl))
                .WithMessage("LogoUrl cannot exceed 200 characters.");

            RuleFor(x => x.FaviconUrl)
                .MaximumLength(200)
                .When(x => !string.IsNullOrWhiteSpace(x.FaviconUrl))
                .WithMessage("FaviconUrl cannot exceed 200 characters.");

            RuleFor(x => x.Background)
                .MaximumLength(50)
                .When(x => !string.IsNullOrWhiteSpace(x.Background))
                .WithMessage("Background cannot exceed 50 characters.");

            RuleFor(x => x.Surface)
                .MaximumLength(50)
                .When(x => !string.IsNullOrWhiteSpace(x.Surface))
                .WithMessage("Surface cannot exceed 50 characters.");

            RuleFor(x => x.Shadow)
                .MaximumLength(50)
                .When(x => !string.IsNullOrWhiteSpace(x.Shadow))
                .WithMessage("Shadow cannot exceed 50 characters.");

            RuleFor(x => x.FontFamily)
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.FontFamily))
                .WithMessage("FontFamily cannot exceed 100 characters.");

            When(x => x.DarkMode != null, () =>
            {
                RuleFor(x => x.DarkMode.Background)
                    .MaximumLength(100)
                    .WithMessage("DarkMode Background cannot exceed 100 characters.");

                RuleFor(x => x.DarkMode.Surface)
                    .MaximumLength(100)
                    .WithMessage("DarkMode Surface cannot exceed 100 characters.");

                RuleFor(x => x.DarkMode.Text)
                    .MaximumLength(100)
                    .WithMessage("DarkMode Text cannot exceed 100 characters.");
            });
        }
    }
}
