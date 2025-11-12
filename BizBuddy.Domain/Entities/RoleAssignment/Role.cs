using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Account;

namespace BizBuddy.Domain.Entities.RoleAssignment;


[Table(nameof(Role), Schema = "RoleAssignment")]
public class Role : BaseEntityTenant
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    public string? Description { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}
