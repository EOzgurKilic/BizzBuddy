using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.RoleAssignment;
using BizBuddy.Domain.Entities.Tenats;

namespace BizBuddy.Domain.Entities.Account;

[Table(nameof(User), Schema = "Account")]

public class User : BaseEntityTenant
{
    public long Id { get; set; }
    public string DisplayName { get; set; }

    public string Email { get; set; }

    public string? Phone { get; set; }

    public string PasswordHash { get; set; }
    public long RoleId { get; set; }
    public Role Role { get; set; }

}
