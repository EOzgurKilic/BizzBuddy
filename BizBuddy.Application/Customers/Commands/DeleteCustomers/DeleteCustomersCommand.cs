using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Customers.Commands.DeleteCustomers;

public record DeleteCustomersCommand(long Id) : IRequest<Result>;
public class DeleteCustomersCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteCustomersCommand, Result>
{
    public async Task<Result> Handle(DeleteCustomersCommand request, CancellationToken ct)
    {
        var entity = await context.Customer.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Customer not found.");

        context.Customer.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

