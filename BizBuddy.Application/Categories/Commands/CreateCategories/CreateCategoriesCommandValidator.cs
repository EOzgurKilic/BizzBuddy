using System;
using BizBuddy.Application.Categories.Commands.CreateCategories;
using FluentValidation;

namespace BizBuddy.Application.Categories.Commands;
public class CreateCategoriesCommandValidator : AbstractValidator<CreateCategoriesCommand>
{
    public CreateCategoriesCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori adı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Kategori adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.ParentId)
            .GreaterThan(0).When(x => x.ParentId.HasValue)
            .WithMessage("ParentId sıfırdan büyük olmalıdır.");

        RuleFor(x => x.Type)
            .MaximumLength(50).WithMessage("Kategori tipi en fazla 50 karakter olabilir.");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0)
            .When(x => x.SortOrder.HasValue)
            .WithMessage("Sıralama numarası negatif olamaz.");

    }
}

