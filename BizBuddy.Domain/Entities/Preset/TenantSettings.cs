using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.RoleAssignment;

namespace BizBuddy.Domain.Entities.Preset;

[Table(nameof(TenantSettings), Schema = "Preset")]
public class TenantSettings : BaseEntityTenant
{
    public int Id { get; set; }
    public List<string> EnabledModules { get; set; }
    public List<string> MenuOrder { get; set; }

    public Branding Branding { get; set; }
    
    public int BrandingId { get; set; }
    
}
