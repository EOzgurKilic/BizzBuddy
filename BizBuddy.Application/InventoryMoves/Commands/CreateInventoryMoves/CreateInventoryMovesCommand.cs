using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.InventoryMoves;
using MediatR;

namespace BizBuddy.Application.InventoryMoves.Commands.CreateInventoryMoves;

public record CreateInventoryMovesCommand : IRequest<Result<long>>
{
    public int ProductId { get; set; }

    public decimal Qty { get; set; }
    public string? Reason { get; set; }

    public string? RefType { get; set; }

    public int? RefId { get; set; }
}
public class CreateInventoryMovesCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateInventoryMovesCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateInventoryMovesCommand request, CancellationToken cancellationToken)
    {

        var entity = new InventoryMove
        {
            ProductId = request.ProductId,
            Qty = request.Qty,
            Reason = request.Reason,
            RefType = request.RefType,
            RefId = request.RefId,
        };

        context.InventoryMove.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }




}
