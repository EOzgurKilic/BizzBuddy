using FluentValidation;

namespace BizBuddy.Application.RoleAssignment.Commands.CreateRole
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("Role name is required.")
                .MinimumLength(3)
                .WithMessage("Role name must contain at least 3 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500)
                .When(x => !string.IsNullOrWhiteSpace(x.Description))
                .WithMessage("Description cannot exceed 500 characters.");

            RuleForEach(x => x.UserIds)
                .GreaterThan(0)
                .WithMessage("UserId must be greater than 0.");
        }
    }
}
