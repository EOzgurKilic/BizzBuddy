using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.DeleteOrderItem;

public record DeleteOrderItemCommand(long Id) : IRequest<Result>;
public class DeleteOrderItemCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteOrderItemCommand, Result>
{
    public async Task<Result> Handle(DeleteOrderItemCommand request, CancellationToken ct)
    {
        var entity = await context.OrderItem.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Customer not found.");

        context.OrderItem.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

