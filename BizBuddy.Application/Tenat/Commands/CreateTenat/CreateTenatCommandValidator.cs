using System;
using FluentValidation;

namespace BizBuddy.Application.Tenat.Commands.CreateTenat;

public class CreatePersonCommandValidator : AbstractValidator<CreateTenatCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(x => x.Name)
         .NotEmpty().WithMessage("FirstName cannot be left empty.");


    }
}

