using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Orders;

namespace BizBuddy.Domain.Entities.Customers;


[Table(nameof(Customer), Schema = "Customers")]

public class Customer : BaseEntityTenant
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Tags { get; set; }
    public string? Notes { get; set; }
    public string? Address { get; set; }
    public string? Password { get; set; }

    public ICollection<Order>? Orders { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
