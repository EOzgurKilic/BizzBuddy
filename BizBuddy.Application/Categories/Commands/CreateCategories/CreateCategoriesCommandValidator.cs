using System;
using BizBuddy.Application.Categories.Commands.CreateCategories;
using FluentValidation;

namespace BizBuddy.Application.Categories.Commands;


//Localized into English
public class CreateCategoriesCommandValidator : AbstractValidator<CreateCategoriesCommand>
{
    public CreateCategoriesCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name can't be left blank.")
            .MinimumLength(2).WithMessage("Category name can't consist of less than 2 characters.")
            .MaximumLength(100).WithMessage("Category name can be up to 100 characters.");

        RuleFor(x => x.ParentId)
            .GreaterThan(0).When(x => x.ParentId.HasValue)
            .WithMessage("ParentId must be higher than 0.");

        RuleFor(x => x.Type)
            .MaximumLength(50).WithMessage("Category type can't exceed 50 characters.");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0)
            .When(x => x.SortOrder.HasValue)
            .WithMessage("Order number can't be a negative value.");
    }
}

