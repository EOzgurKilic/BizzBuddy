using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Preset;
using BizBuddy.Domain.Entities.RoleAssignment;

namespace BizBuddy.Application.Preset.Queries.GetTenantSettingsDetail;

public class TenantSettingsDetailDto: IMapFrom<TenantSettings>
{
    public int Id { get; set; }
    
    public List<string> EnabledModules { get; set; } = new();
    public List<string> MenuOrder { get; set; } = new();

    public BrandingDetailDto Branding { get; set; } = default!;
    public int BrandingId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TenantSettings, TenantSettingsDetailDto>()
               .ReverseMap();

        profile.CreateMap<Branding, BrandingDetailDto>().ReverseMap();
    }
}

// Branding için gerekli olan alt DTO
public class BrandingDetailDto
{
    public int Id { get; set; }
    public string? LogoUrl { get; set; }
    public string? PrimaryColor { get; set; }
    public string? CompanyName { get; set; }
}