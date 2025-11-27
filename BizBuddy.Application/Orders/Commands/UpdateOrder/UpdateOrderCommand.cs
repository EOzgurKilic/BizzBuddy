using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizBuddy.Application.Orders.Commands.UpdateOrder;


public record UpdateOrderCommand : IRequest<Result>
{
        public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Status { get; set; }
    public string? Channel { get; set; }

    public decimal Subtotal { get; set; }
    public decimal? DiscountTotal { get; set; }
    public decimal? TaxTotal { get; set; }
    public decimal Total { get; set; }

    public string PaymentMethod { get; set; }

    public string? Notes { get; set; }
    public string? Custom { get; set; }

    public List<OrderItemDto> Items { get; set; } = new();
    public List<OrderPaymentDto> Payments { get; set; } = new();


}
public class OrderItemDto
{
    public int ProductId { get; set; }
    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public string? Notes { get; set; }
    public string? Custom { get; set; }
}

public class OrderPaymentDto
{
    public decimal Amount { get; set; }
    public string Method { get; set; }
    public string? ProviderRef { get; set; }
    public string? Notes { get; set; }
}



public class UpdateOrderCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateOrderCommand, Result>
{
    public async Task<Result> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Order.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null)
            return Result.Failure("Order not found");

      

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}