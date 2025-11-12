using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Products;

namespace BizBuddy.Domain.Entities.Orders;


[Table(nameof(Order), Schema = "Orders")]

public class OrderItem : BaseEntityTenant
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal => Qty * UnitPrice;

    public string? Notes { get; set; }
    public string? Custom { get; set; }

}
