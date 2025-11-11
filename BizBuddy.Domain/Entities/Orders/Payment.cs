using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.Orders;


[Table(nameof(Payment), Schema = "Orders")]

public class Payment : BaseEntityTenant
{

    public int Id { get; set; }
    public Order OrderId { get; set; }
    public decimal Amount { get; set; }

    public string Method { get; set; } // cash|card|transfer|mixed
    public string? ProviderRef { get; set; }
    public DateTime PaidAt { get; set; }

    public string? Notes { get; set; }

}
