using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Orders;

namespace BizBuddy.Application.Orders.Queries.GetPaymentWithPagination;

public class PaymentListDto: IMapFrom<Payment>
{
    public int Id { get; set; }
    public int OrderId { get; set; }

    public decimal Amount { get; set; }
    public string Method { get; set; } = default!;
    public string? ProviderRef { get; set; }
    public DateTime PaidAt { get; set; }
    public string? Notes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Payment, PaymentListDto>()
               .ReverseMap();
    }
}
