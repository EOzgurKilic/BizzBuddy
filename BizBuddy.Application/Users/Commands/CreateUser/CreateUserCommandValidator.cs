using System;
using FluentValidation;

namespace BizBuddy.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.DisplayName)
         .NotEmpty().WithMessage("DisplayName boş bırakılamaz.");

        RuleFor(x => x.Email)
       .NotEmpty().WithMessage("Email boş bırakılamaz.");
        RuleFor(x => x.PasswordHash)
        .NotEmpty().WithMessage("Şifre boş bırakılamaz.")
        .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
        .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
        .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
        .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
        .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir. (!, @, #, $, vs.)"); 
        RuleFor(x => x.RoleId)
       .NotEmpty().WithMessage("RoleId boş bırakılamaz.");


    }
}

