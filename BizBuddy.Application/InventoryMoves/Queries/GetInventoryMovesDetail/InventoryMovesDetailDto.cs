using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.InventoryMoves;
using BizBuddy.Domain.Entities.Products;

namespace BizBuddy.Application.InventoryMoves.Queries.GetInventoryMovesDetail;

public class InventoryMovesDetailDto : IMapFrom<InventoryMove>
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public decimal Qty { get; set; }
    public string? Reason { get; set; }

    public string? RefType { get; set; }

    public int? RefId { get; set; }

    public string Name { get; set; }
    public string? CategoryName { get; set; }
    public decimal Price { get; set; }
    public decimal? StockQty { get; set; }
    public string? Unit { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, InventoryMovesDetailDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.StockQty, opt => opt.MapFrom(src => src.StockQty));
    }
}
