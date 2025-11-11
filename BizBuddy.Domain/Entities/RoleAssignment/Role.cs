using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Account;

namespace BizBuddy.Domain.Entities.RoleAssignment;


[Table(nameof(Role), Schema = "RoleAssignment")]
public class Role : BaseEntityTenant
{
    public long Id { get; set; }
    public User User { get; set; }
    public long UserId { get; set; }

    public string RoleName { get; set; }

    public DateTime? EffectiveFrom { get; set; }

    public DateTime? EffectiveTo { get; set; }

}
