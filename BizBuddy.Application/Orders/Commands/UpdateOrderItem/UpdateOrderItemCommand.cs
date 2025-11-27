using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.UpdateOrderItem;


public record UpdateOrderItemCommand : IRequest<Result>
{
 public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal LineTotal => Qty * UnitPrice;

    public string? Notes { get; set; }
    public string? Custom { get; set; }
}

public class UpdateOrderItemCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateOrderItemCommand, Result>
{
    public async Task<Result> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.OrderItem.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("OrderItem not found");
        
        entity.OrderId = request.OrderId;
        entity.ProductId = request.ProductId;
        entity.UnitPrice = request.UnitPrice;
        entity.Notes = request.Notes;
        entity.Custom = request.Custom;
        entity.Qty = request.Qty;
       

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}