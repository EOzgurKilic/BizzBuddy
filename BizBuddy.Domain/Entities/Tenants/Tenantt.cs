using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.Tenats;

[Table(nameof(Tenantt), Schema = "Tenants")]
public class Tenantt : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string? PresetName { get; set; }
}
