using FluentValidation;

namespace BizBuddy.Application.Categories.Commands.UpdateCategories;

public class UpdateCategoriesCommandValidator : AbstractValidator<UpdateCategoriesCommand>
{
    public UpdateCategoriesCommandValidator()
    {
        
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0.");

        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name can't be left blank.")
            .MinimumLength(2).WithMessage("Category name must contain at least 2 characters.")
            .MaximumLength(100).WithMessage("Category name can be up to 100 characters.");

        
        RuleFor(x => x.ParentId)
            .GreaterThan(0).When(x => x.ParentId.HasValue)
            .WithMessage("ParentId must be higher than 0.");

        
        RuleFor(x => x)
            .Must(x => x.ParentId != x.Id)
            .WithMessage("A category cannot be its own parent.");

       
        RuleFor(x => x.Type)
            .MaximumLength(50)
            .When(x => !string.IsNullOrEmpty(x.Type))
            .WithMessage("Category type can't exceed 50 characters.");

        
        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0)
            .When(x => x.SortOrder.HasValue)
            .WithMessage("Order number can't be a negative value.");
    }
}
