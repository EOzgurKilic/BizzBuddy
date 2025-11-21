using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.InventoryMoves.Commands.DeleteInventoryMoves;

public record DeleteInventoryMovesCommand(long Id) : IRequest<Result>;
public class DeleteInventoryMovesCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteInventoryMovesCommand, Result>
{
    public async Task<Result> Handle(DeleteInventoryMovesCommand request, CancellationToken ct)
    {
        var entity = await context.InventoryMove.FirstOrDefaultAsync(g => g.Id == request.Id, ct);

        if (entity==null)
            return Result.Failure("Customer not found.");

        context.InventoryMove.Remove(entity);
        await context.SaveChangesAsync(ct);
        return Result.Success();
    }
}

