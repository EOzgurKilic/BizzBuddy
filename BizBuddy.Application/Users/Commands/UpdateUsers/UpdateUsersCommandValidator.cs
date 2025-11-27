using FluentValidation;

namespace BizBuddy.Application.Users.Commands.UpdateUsers;

public class UpdateUsersCommandValidator : AbstractValidator<UpdateUsersCommand>
{
    public UpdateUsersCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0");

        RuleFor(x => x.DisplayName)
            .NotEmpty().WithMessage("DisplayName is required")
            .MaximumLength(150).WithMessage("DisplayName cannot exceed 150 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Phone)
            .MaximumLength(20).When(x => !string.IsNullOrWhiteSpace(x.Phone))
            .WithMessage("Phone cannot exceed 20 characters");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("PasswordHash is required");

        RuleFor(x => x.RoleId)
            .GreaterThan(0)
            .WithMessage("RoleId must be greater than 0");
    }
}
