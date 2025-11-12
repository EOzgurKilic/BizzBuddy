// using FluentValidation;

// namespace BizBuddy.Application.Features.Persons.Commands
// {
//     public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
//     {
//         public CreatePersonCommandValidator()
//         {
//            RuleFor(x => x.FirstName)
//     .NotEmpty().WithMessage("FirstName boş bırakılamaz.")
//     .MaximumLength(1).WithMessage("FirstName en fazla 50 karakter olabilir.");

// RuleFor(x => x.LastName)
//     .NotEmpty().WithMessage("LastName boş bırakılamaz.")
//     .MaximumLength(1).WithMessage("LastName en fazla 50 karakter olabilir.");

//         }
//     }
// }
