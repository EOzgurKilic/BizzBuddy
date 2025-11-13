using FluentValidation;

namespace BizBuddy.Application.Customers.Commands.CreateCustomers;

public class CreateCustomersValidator : AbstractValidator<CreateCustomersCommand>
{
    public CreateCustomersValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Müşteri adı boş bırakılamaz.")
            .MinimumLength(2).WithMessage("Müşteri adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Müşteri adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Email)
            .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage("Geçerli bir e-posta adresi giriniz.");

        RuleFor(x => x.Phone)
            .Matches(@"^\+?[0-9\s\-]{10,15}$")
            .When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage("Geçerli bir telefon numarası giriniz.");

        RuleFor(x => x.Address)
            .MaximumLength(250).WithMessage("Adres 250 karakterden uzun olamaz.");

        RuleFor(x => x.Password)
            .MinimumLength(8).When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("Şifre en az 8 karakter olmalıdır.")
            .Matches("[A-Z]").When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("Şifre en az bir büyük harf içermelidir.")
            .Matches("[a-z]").When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("Şifre en az bir küçük harf içermelidir.")
            .Matches("[0-9]").When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("Şifre en az bir rakam içermelidir.")
            .Matches("[^a-zA-Z0-9]").When(x => !string.IsNullOrEmpty(x.Password))
            .WithMessage("Şifre en az bir özel karakter içermelidir (!, @, #, $, vs.).");
    }
}
