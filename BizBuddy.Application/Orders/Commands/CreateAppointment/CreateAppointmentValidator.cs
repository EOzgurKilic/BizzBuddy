using System;
using BizBuddy.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.CreateAppointment;


public class CreateAppointmentValidator : AbstractValidator<CreateAppointmentCommand>
{
    private readonly IApplicationDbContext _context;
    public CreateAppointmentValidator(IApplicationDbContext context)
    {
        _context = context;
        RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("CustomerId must be greater than 0.").MustAsync(CustomerExists).WithMessage("Customer with the given ID does not exist.");

        RuleFor(x => x.Start)
            .NotEmpty().WithMessage("Start date can't be left empty.")
            .Must(d => d > DateTime.MinValue).WithMessage("Please enter a valid date.")
            .Must(d => d >= DateTime.UtcNow.AddMinutes(-1))
            .WithMessage("Start date can't be a past date.");

        RuleFor(x => x.End)
            .NotEmpty().WithMessage("End Date can't be left empty.")
            .GreaterThan(x => x.Start).WithMessage("The end date must come after the start date.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status can't be left blank.")
            .Must(s => new[] { "pending", "approved", "cancelled", "completed" }.Contains(s))
            .WithMessage("Invalid appointment status. It must be one of the following: \"pending\", \"approved\", \"cancelled\", \"completed.\"");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes can't exceed 500 characters.");

        RuleFor(x => x.Custom)
            .Must(x => string.IsNullOrWhiteSpace(x) || x.Length <= 2000)
            .WithMessage("Custom fields can't be longer than 2000 characters.");
    }
    private async Task<bool> CustomerExists(int customerId, CancellationToken ct)
    {
        return await _context.Customer.AnyAsync(c => c.Id == customerId, ct);
    }
}

