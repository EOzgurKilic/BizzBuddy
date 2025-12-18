using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Orders;

namespace BizBuddy.Application.Orders.Queries.GetOrderWithPagination;

public class OrderListDto : IMapFrom<Order>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = default!;

    public string Status { get; set; } = default!;
    public string? Channel { get; set; }
    public decimal Subtotal { get; set; }
    public decimal? DiscountTotal { get; set; }
    public decimal? TaxTotal { get; set; }
    public decimal Total { get; set; }

    public string PaymentMethod { get; set; } = default!;
    public DateTime? PaidAt { get; set; }
    public string? Notes { get; set; }
    public ICollection<OrderItemSummaryListDto> Items { get; set; } = new List<OrderItemSummaryListDto>();
    public ICollection<PaymentSummaryListDto> Payments { get; set; } = new List<PaymentSummaryListDto>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderListDto>()
            .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.Name));
        profile.CreateMap<OrderItem, OrderItemSummaryListDto>();
        profile.CreateMap<Payment, PaymentSummaryListDto>();
    }
}

public class OrderItemSummaryListDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class PaymentSummaryListDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = default!;
    public DateTime PaidAt { get; set; }
}