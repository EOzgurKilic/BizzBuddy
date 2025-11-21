using System;
using FluentValidation;

namespace BizBuddy.Application.CustomFieldDefs.Commands.CreateCustomFieldDefs;

public class CreateCustomFieldDefsValidator : AbstractValidator<CreateCustomFieldDefsCommand>
{
    public CreateCustomFieldDefsValidator()
    {
        RuleFor(x => x.EntityType)
            .NotEmpty().WithMessage("EntityType can't be left blank.")
            .Must(type => new[] { "customer", "product", "order", "appointment", "staff" }
                .Contains(type.ToLower()))
            .WithMessage("EntityType can be merely one of the following; 'customer', 'product', 'order', 'appointment' or 'staff'.");

        RuleFor(x => x.Key)
            .NotEmpty().WithMessage("Key can't be empty.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("Key may merely contain letters, numbers, and underscores.")
            .MaximumLength(50).WithMessage("Key can't be longer than 50 characters.");

        RuleFor(x => x.Label)
            .NotEmpty().WithMessage("Label (displayed name) can't be left blank.")
            .MaximumLength(100).WithMessage("Label can't be longer than 100 characters.");

        RuleFor(x => x.DataType)
            .NotEmpty().WithMessage("DataType can't be left blank.")
            .Must(type => new[] { "text", "number", "date", "datetime", "select", "toggle" }
                .Contains(type.ToLower()))
            .WithMessage("DataType can be merely one of the following; 'text', 'number', 'date', 'datetime', 'select' or 'toggle'.");

        RuleFor(x => x.Order)
            .GreaterThanOrEqualTo(0).WithMessage("Order (value) can't be negative.");

        RuleFor(x => x.Options)
            .NotEmpty()
            .When(x => x.DataType.Equals("select", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Options field can't be left blank when the DataType is 'select'.");

        RuleFor(x => x.Options)
            .Empty()
            .When(x => !x.DataType.Equals("select", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Options can be only used in 'select' type.");
    }
}
