using FluentValidation;

namespace BizBuddy.Application.Customers.Commands.CreateCustomers;
//Localized into English
public class CreateCustomersValidator : AbstractValidator<CreateCustomersCommand>
{
    //the phone number can be left empty.
    //tags and notes can be left empty.
    //Email can be left empty.
    //Valid email structure can be breached and manipulated. Exp: 54164sd@r
    public CreateCustomersValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Customer name can't left blank.")
            .MinimumLength(2).WithMessage("Customer name must be consisting of at least 2 characters.")
            .MaximumLength(100).WithMessage("Customer name can't be longer than 100 characters.");

        RuleFor(x => x.Email)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Please enter a valid email address.");

        RuleFor(x => x.Phone)
            .Matches(@"^\+?[0-9\s\-]{10,15}$")
            .When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage("Please enter a valid phone number."); 

        RuleFor(x => x.Address)
            .MaximumLength(250).WithMessage("Address can't be longer than 250 characters.");

        RuleFor(x => x.Password)
            .MinimumLength(8).When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("The password must be at least 8 characters.")
            .Matches("[A-Z]").When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("The password must contain an upper case letter.")
            .Matches("[a-z]").When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("The password must contain an lower case letter.")
            .Matches("[0-9]").When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("The password must contain at least one digit.")
            .Matches("[^a-zA-Z0-9]").When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("The password must contain at least one special character (!, @, #, $, etc.).");
    }
}
