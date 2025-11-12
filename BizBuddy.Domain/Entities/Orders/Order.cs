using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Customers;

namespace BizBuddy.Domain.Entities.Orders;


[Table(nameof(Order), Schema = "Orders")]

public class Order : BaseEntityTenant
{
    public int Id { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }

    public string Status { get; set; }
    public string? Channel { get; set; }
    public decimal Subtotal { get; set; }
    public decimal? DiscountTotal { get; set; }
    public decimal? TaxTotal { get; set; }
    public decimal Total { get; set; }

    public string PaymentMethod { get; set; }
    public DateTime? PaidAt { get; set; }

    public string? Notes { get; set; }
    public string? Custom { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
