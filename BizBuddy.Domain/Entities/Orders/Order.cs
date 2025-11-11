using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Customers;

namespace BizBuddy.Domain.Entities.Orders;


[Table(nameof(Order), Schema = "Orders")]

public class Order : BaseEntityTenant
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    public int CustomerId { get; set; }

    public string Status { get; set; } // draft|confirmed|paid|canceled
    public string? Channel { get; set; } // pos|online|phone (ops.)

    public decimal Subtotal { get; set; }
    public decimal? DiscountTotal { get; set; }
    public decimal? TaxTotal { get; set; }
    public decimal Total { get; set; }

    public string PaymentMethod { get; set; } // cash|card|transfer
    public DateTime? PaidAt { get; set; }

    public string? Notes { get; set; }
    public string? Custom { get; set; } // jsonb -> nvarchar(max) veya JSON tipinde

    // Navigation
    public ICollection<OrderItem> Items { get; set; }
    public ICollection<Payment> Payments { get; set; }

}
