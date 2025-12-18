using System;
using System.Collections.Generic;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Orders;

namespace BizBuddy.Application.Orders.Queries.GetOrderDetail;

public class OrderDetailDto : IMapFrom<Order>
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
    public ICollection<OrderItemSummaryDetailDto> Items { get; set; } = new List<OrderItemSummaryDetailDto>();
    public ICollection<PaymentSummaryDetailDto> Payments { get; set; } = new List<PaymentSummaryDetailDto>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDetailDto>()
            .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.Name));

        // Alt detayların mapping kuralları
        profile.CreateMap<OrderItem, OrderItemSummaryDetailDto>();
        profile.CreateMap<Payment, PaymentSummaryDetailDto>();
    }
}

public class OrderItemSummaryDetailDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class PaymentSummaryDetailDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Method { get; set; } = default!;
    public DateTime PaidAt { get; set; }
}