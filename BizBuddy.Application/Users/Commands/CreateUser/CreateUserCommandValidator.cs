using System;
using FluentValidation;

namespace BizBuddy.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.DisplayName)
         .NotEmpty().WithMessage("DisplayName can't be left blank.");

        RuleFor(x => x.Email)
       .NotEmpty().WithMessage("Email can't be left blank.");
        RuleFor(x => x.PasswordHash)
        .NotEmpty().WithMessage("Password can't be left blank.")
        .MinimumLength(8).WithMessage("Password length can't be less than 8 characters.")
        .Matches("[A-Z]").WithMessage("Password must contain at least one upper case letter.")
        .Matches("[a-z]").WithMessage("Password must contain at least one lower case letter.")
        .Matches("[0-9]").WithMessage("Password must contain at least one number.")
        .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character. (!, @, #, $, etc.)"); 
        RuleFor(x => x.RoleId)
       .NotEmpty().WithMessage("RoleId can't be left blank.");


    }
}

