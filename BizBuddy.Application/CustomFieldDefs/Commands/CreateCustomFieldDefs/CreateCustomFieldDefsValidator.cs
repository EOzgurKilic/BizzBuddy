using System;
using FluentValidation;

namespace BizBuddy.Application.CustomFieldDefs.Commands.CreateCustomFieldDefs;

public class CreateCustomFieldDefsValidator : AbstractValidator<CreateCustomFieldDefsCommand>
{
    public CreateCustomFieldDefsValidator()
    {
        RuleFor(x => x.EntityType)
            .NotEmpty().WithMessage("EntityType boş bırakılamaz.")
            .Must(type => new[] { "customer", "product", "order", "appointment", "staff" }
                .Contains(type.ToLower()))
            .WithMessage("EntityType yalnızca 'customer', 'product', 'order', 'appointment' veya 'staff' olabilir.");

        RuleFor(x => x.Key)
            .NotEmpty().WithMessage("Key boş bırakılamaz.")
            .Matches("^[a-zA-Z0-9_]+$").WithMessage("Key sadece harf, rakam ve alt çizgi (_) içerebilir.")
            .MaximumLength(50).WithMessage("Key 50 karakterden uzun olamaz.");

        RuleFor(x => x.Label)
            .NotEmpty().WithMessage("Label (görünen ad) boş bırakılamaz.")
            .MaximumLength(100).WithMessage("Label 100 karakterden uzun olamaz.");

        RuleFor(x => x.DataType)
            .NotEmpty().WithMessage("DataType boş bırakılamaz.")
            .Must(type => new[] { "text", "number", "date", "datetime", "select", "toggle" }
                .Contains(type.ToLower()))
            .WithMessage("DataType yalnızca 'text', 'number', 'date', 'datetime', 'select' veya 'toggle' olabilir.");

        RuleFor(x => x.Order)
            .GreaterThanOrEqualTo(0).WithMessage("Order (sıralama değeri) negatif olamaz.");

        RuleFor(x => x.Options)
            .NotEmpty()
            .When(x => x.DataType.Equals("select", StringComparison.OrdinalIgnoreCase))
            .WithMessage("DataType 'select' olduğunda Options alanı dolu olmalıdır.");

        RuleFor(x => x.Options)
            .Empty()
            .When(x => !x.DataType.Equals("select", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Options yalnızca 'select' tipinde kullanılabilir.");
    }
}
