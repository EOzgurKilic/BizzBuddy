using System;
using FluentValidation;

namespace BizBuddy.Application.Categories.Commands.DeleteCategories;

public class DeleteCategoriesCommandValidator : AbstractValidator<DeleteCategoriesCommand>
{
    public DeleteCategoriesCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id cannot be empty.")
            .GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
