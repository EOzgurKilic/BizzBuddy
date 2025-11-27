using FluentValidation;

namespace BizBuddy.Application.Customers.Commands.UpdateCustomers;

public class UpdateCustomersCommandValidator : AbstractValidator<UpdateCustomersCommand>
{
    public UpdateCustomersCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Customer name can't be left blank.")
            .MinimumLength(2).WithMessage("Customer name must contain at least 2 characters.")
            .MaximumLength(100).WithMessage("Customer name can be up to 100 characters.");

        RuleFor(x => x.Phone)
            .Matches(@"^[0-9+\-() ]+$")
            .When(x => !string.IsNullOrWhiteSpace(x.Phone))
            .WithMessage("Phone number format is invalid.")
            .MaximumLength(20).WithMessage("Phone number can't exceed 20 characters.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .WithMessage("Email format is invalid.")
            .MaximumLength(100).WithMessage("Email can't exceed 100 characters.");

        RuleFor(x => x.Tags)
            .MaximumLength(250)
            .When(x => !string.IsNullOrWhiteSpace(x.Tags))
            .WithMessage("Tags can't exceed 250 characters.");

        RuleFor(x => x.Notes)
            .MaximumLength(500)
            .When(x => !string.IsNullOrWhiteSpace(x.Notes))
            .WithMessage("Notes can't exceed 500 characters.");

        RuleFor(x => x.Address)
            .MaximumLength(250)
            .When(x => !string.IsNullOrWhiteSpace(x.Address))
            .WithMessage("Address can't exceed 250 characters.");

        RuleFor(x => x.Password)
            .MinimumLength(6)
            .When(x => !string.IsNullOrWhiteSpace(x.Password))
            .WithMessage("Password must contain at least 6 characters.");
    }
}
