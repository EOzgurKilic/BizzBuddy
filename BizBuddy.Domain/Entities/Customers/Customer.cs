using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.Customers;


[Table(nameof(Customer), Schema = "Customers")]

public class Customer : BaseEntityTenant
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Tags { get; set; }

    public string? Notes { get; set; }

    public string? Address { get; set; }
    
    public string Password { get; set; }
}
