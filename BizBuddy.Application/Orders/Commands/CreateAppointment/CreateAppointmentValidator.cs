using System;
using FluentValidation;

namespace BizBuddy.Application.Orders.Commands.CreateAppointment;


public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentValidator()
    {
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("CustomerId 0'dan büyük olmalıdır.");

        RuleFor(x => x.Start)
            .NotEmpty().WithMessage("Başlangıç tarihi boş bırakılamaz.")
            .Must(d => d > DateTime.MinValue).WithMessage("Geçerli bir başlangıç tarihi giriniz.")
            .Must(d => d >= DateTime.UtcNow.AddMinutes(-1))
            .WithMessage("Başlangıç zamanı geçmiş bir tarih olamaz.");

        RuleFor(x => x.End)
            .NotEmpty().WithMessage("Bitiş tarihi boş bırakılamaz.")
            .GreaterThan(x => x.Start).WithMessage("Bitiş tarihi başlangıç tarihinden büyük olmalıdır.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status boş bırakılamaz.")
            .Must(s => new[] { "pending", "approved", "cancelled", "completed" }.Contains(s))
            .WithMessage("Geçersiz appointment durumu.");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notlar 500 karakterden uzun olamaz.");

        RuleFor(x => x.Custom)
            .Must(x => string.IsNullOrWhiteSpace(x) || x.Length <= 2000)
            .WithMessage("Custom alanı 2000 karakterden uzun olamaz.");
    }
}

