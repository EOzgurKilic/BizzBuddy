using FluentValidation;

namespace BizBuddy.Application.Staff.Commands
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.")
                .MinimumLength(2)
                .WithMessage("Name must be at least 2 characters.");

            RuleFor(x => x.SurName)
                .NotEmpty()
                .WithMessage("SurName is required.")
                .MinimumLength(2)
                .WithMessage("SurName must be at least 2 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email must be a valid email address.");

            RuleFor(x => x.Phone)
                .GreaterThan(0)
                .WithMessage("Phone must be a valid positive number.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
        }
    }
}
