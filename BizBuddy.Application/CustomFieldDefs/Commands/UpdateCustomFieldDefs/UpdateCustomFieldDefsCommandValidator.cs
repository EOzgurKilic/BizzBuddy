using FluentValidation;

namespace BizBuddy.Application.CustomFieldDefs.Commands.UpdateCustomFieldDefs;

public class UpdateCustomFieldDefsCommandValidator : AbstractValidator<UpdateCustomFieldDefsCommand>
{
    public UpdateCustomFieldDefsCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(x => x.EntityType)
            .NotEmpty().WithMessage("EntityType is required.")
            .MaximumLength(100);

        RuleFor(x => x.Key)
            .NotEmpty().WithMessage("Key is required.")
            .MaximumLength(100);

        RuleFor(x => x.Label)
            .NotEmpty().WithMessage("Label is required.")
            .MaximumLength(200);

        RuleFor(x => x.DataType)   
            .NotEmpty().WithMessage("DataType is required.")
            .Must(x => AllowedDataTypes.Contains(x))
            .WithMessage("Invalid DataType. Allowed values: text, number, date, select, multiselect, checkbox.");

        RuleFor(x => x.Order)
            .GreaterThanOrEqualTo(0).WithMessage("Order must be >= 0.");

        When(x => x.DataType is "select" or "multiselect", () =>
        {
            RuleFor(x => x.Options)
                .NotNull().WithMessage("Options is required for select or multiselect types.")
                .Must(opt => opt!.Length > 0).WithMessage("Options must contain at least one item.");
        });
    }

    private static readonly string[] AllowedDataTypes =
    [
        "text", "number", "date", "select", "multiselect", "checkbox"
    ];
}
