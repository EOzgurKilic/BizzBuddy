using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.RoleAssignment;

namespace BizBuddy.Application.RoleAssignment.Queries.GetBrandingDetail;

public class BrandingDto: IMapFrom<Branding>
{
    public int Id { get; set; }
    public string BrandName { get; set; } = default!;
    public string? LogoUrl { get; set; }
    public string? FaviconUrl { get; set; }
    
    public string? Background { get; set; }
    public string? Surface { get; set; }
    public string? Shadow { get; set; }
    public string? FontFamily { get; set; }

    public DarkModeSettingsDetailDto? DarkMode { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Branding, BrandingDto>().ReverseMap();

        profile.CreateMap<DarkModeSettings, DarkModeSettingsDetailDto>().ReverseMap();
    }
}

public class DarkModeSettingsDetailDto
{
    public bool Enabled { get; set; }
    public string? Background { get; set; }
    public string? Surface { get; set; }
    public string? Text { get; set; }
}
