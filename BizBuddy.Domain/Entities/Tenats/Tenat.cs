using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.Tenats;


[Table(nameof(Tenat), Schema = "Tenats")]
public class Tenat : BaseEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? PresetName { get; set; }
}
