using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Customers;

namespace BizBuddy.Domain.Entities.Orders;

[Table(nameof(Appointment), Schema = "Orders")]

public class Appointment : BaseEntityTenant
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    public int CustomerId { get; set; }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public string Status { get; set; } 
    public string? Notes { get; set; }
    public string? Custom { get; set; }
}
