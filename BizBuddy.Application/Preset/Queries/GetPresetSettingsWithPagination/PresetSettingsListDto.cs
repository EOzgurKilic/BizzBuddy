using System;
using AutoMapper;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Preset;

namespace BizBuddy.Application.Preset.Queries.GetPresetSettingsWithPagination;

public class PresetSettingsListDto: IMapFrom<PresetSettings>
{
public int Id { get; set; }
    
    public List<string> EnabledModules { get; set; } = new();
    public List<string> MenuOrder { get; set; } = new();
    
    public string? Notes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PresetSettings, PresetSettingsListDto>()
               .ReverseMap();
    }
}
