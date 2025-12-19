using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Products;

namespace BizBuddy.Application.Products.Queries.GetProductsDetail;

public class ProductsDto : IMapFrom<Product>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    
    // Kategori Bilgileri
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = default!;

    public string? Sku { get; set; }
    public decimal Price { get; set; }
    public decimal? StockQty { get; set; }
    public string? Unit { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductsDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}