using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Customers.Commands.UpdateCustomers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Customers.Commands.UpdateCustomers;

public record UpdateCustomersCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Tags { get; set; }
    public string? Notes { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }
}

public class UpdateCustomersCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateCustomersCommand, Result>
{
    public async Task<Result> Handle(UpdateCustomersCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Customer.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("Customer not found");

        entity.Name = request.Name;
        entity.Phone = request.Phone;
        entity.Email = request.Email;
        entity.Tags = request.Tags;
        entity.Notes = request.Notes;
        entity.Address = request.Address;
        entity.Password = request.Password;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}