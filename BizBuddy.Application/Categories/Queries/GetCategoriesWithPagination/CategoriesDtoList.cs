using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Categories;

namespace BizBuddy.Application.Categories.Queries.GetCategoriesWithPagination;

public class CategoriesDtoList: IMapFrom<Category>
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? ParentId { get; set; }
    public string? Type { get; set; }
    public int? SortOrder { get; set; }

    public string? ParentName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, CategoriesDtoList>()
            .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent != null ? src.Parent.Name : null));
            
       
    }
}