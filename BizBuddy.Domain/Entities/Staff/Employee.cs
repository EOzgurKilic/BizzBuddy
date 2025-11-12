using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Customers;

namespace BizBuddy.Domain.Entities.Staff;

[Table(nameof(Employee), Schema = "Staff")]

public class Employee : BaseEntityTenant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Password { get; set; }

}
