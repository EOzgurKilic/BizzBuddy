using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(long Id) : IRequest<Result>;
public class DeleteOrderCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteOrderCommand, Result>
{
    public async Task<Result> Handle(DeleteOrderCommand request, CancellationToken ct)
    {
        var entity = await context.Order.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Customer not found.");

        context.Order.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

