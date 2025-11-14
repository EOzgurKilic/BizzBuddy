using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Orders;
using MediatR;

namespace BizBuddy.Application.Orders.Commands.CreateOrderItem;


public record CreateOrderItemCommand : IRequest<Result<long>>
{

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set;}

    public string? Notes { get; set; }
    public string? Custom { get; set; }
}
public class CreateOrderItemCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateOrderItemCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {

        var entity = new OrderItem
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            UnitPrice = request.UnitPrice,
            Qty = request.Qty,
            Notes = request.Notes,
            Custom = request.Custom,
        };

        context.OrderItem.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);
    }
}
