using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.InventoryMoves.Commands.UpdateInventoryMoves;

public record UpdateInventoryMovesCommand : IRequest<Result>
{
    public int Id { get; set; }
    public int ProductId { get; set; }

    public decimal Qty { get; set; }
    public string? Reason { get; set; }

    public string? RefType { get; set; }

    public int? RefId { get; set; }
}

public class UpdateInventoryMovesCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateInventoryMovesCommand, Result>
{
    public async Task<Result> Handle(UpdateInventoryMovesCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.InventoryMove.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("InventoryMove not found");

        entity.ProductId = request.ProductId;
        entity.Qty = request.Qty;
        entity.Reason = request.Reason;
        entity.RefType = request.RefType;
        entity.RefId = request.RefId;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}