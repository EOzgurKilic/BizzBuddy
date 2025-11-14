using System;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Domain.Entities.Orders;
using MediatR;

namespace BizBuddy.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<Result<long>>
{
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




public class CreateOrderCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateOrderCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {

        var entity = new Order
        {
            CustomerId = request.CustomerId,
            Status = request.Status,
            Channel = request.Channel,
            Subtotal = request.Subtotal,
            DiscountTotal = request.DiscountTotal,
            TaxTotal = request.TaxTotal,
            Total = request.Total,
            PaymentMethod = request.PaymentMethod,
            Notes = request.Notes,
            Custom = request.Custom
        };

        entity.Items = request.Items.Select(i => new OrderItem
        {
            ProductId = i.ProductId,
            Qty = i.Qty,
            UnitPrice = i.UnitPrice,
            Notes = i.Notes,
            Custom = i.Custom
        }).ToList();

        entity.Payments = request.Payments.Select(p => new Payment
        {
            Amount = p.Amount,
            Method = p.Method,
            ProviderRef = p.ProviderRef,
            Notes = p.Notes
        }).ToList();

        context.Order.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return Result<long>.Success(entity.Id);


    }
}
