using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Orders;

namespace BizBuddy.Application.Orders.Queries.GetOrderItemWithPagination;

public class OrderItemListDto: IMapFrom<OrderItem>
{
    public int Id { get; set; }
    public int OrderId { get; set; }

    // Ürün Bilgileri
    public int ProductId { get; set; }
    public string ProductName { get; set; } = default!;

    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }

    public string? Notes { get; set; }
    public string? Custom { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderItem, OrderItemListDto>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.Qty * src.UnitPrice));
    }
}
