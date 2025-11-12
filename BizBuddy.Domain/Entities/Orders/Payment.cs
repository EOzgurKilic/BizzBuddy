using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.Orders;


[Table(nameof(Payment), Schema = "Orders")]

public class Payment : BaseEntityTenant
{

    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order Order { get; set; }

    public decimal Amount { get; set; }
    public string Method { get; set; } 
    public string? ProviderRef { get; set; }
    public DateTime PaidAt { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

}
