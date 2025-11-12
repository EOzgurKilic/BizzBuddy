using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.RoleAssignment;


[Table(nameof(Branding), Schema = "Preset")]

public class Branding : BaseEntity
{
    public long Id { get; set; }
    public string BrandName { get; set; }
    public string? LogoUrl { get; set; }
    public string? FaviconUrl { get; set; }
    public string? Background { get; set; }
    public string? Surface { get; set; }
    public string? Shadow { get; set; }
    public string? FontFamily { get; set; }

    public DarkModeSettings? DarkMode { get; set; }
}

public sealed class DarkModeSettings
{
    public bool Enabled { get; set; } = false;
    public string? Background { get; set; }
    public string? Surface { get; set; }
    public string? Text { get; set; }
}