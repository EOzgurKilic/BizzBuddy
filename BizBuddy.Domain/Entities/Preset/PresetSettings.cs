using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.Preset;

[Table(nameof(PresetSettings), Schema = "Preset")]

public class PresetSettings : BaseEntity
{
    public long Id { get; set; }
    public List<string> EnabledModules { get; set; }
    public List<string> MenuOrder { get; set; }
    public string? Notes { get; set; }
    public string? EnabledModulesJson { get; set; }   
    public string? MenuOrderJson { get; set; }       
    public string? DefaultFieldsJson { get; set; }    
}
