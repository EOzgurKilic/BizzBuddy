using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Products;

namespace BizBuddy.Domain.Entities.Orders;


[Table(nameof(OrderItem), Schema = "Orders")]

public class OrderItem : BaseEntityTenant
{
   public int Id { get; set; }

    // Order ilişkisi
    public int OrderId { get; set; }
    public Order Order { get; set; }

    // Product ilişkisi
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public decimal Qty { get; set; }
    public decimal UnitPrice { get; set; }


    public decimal LineTotal => Qty * UnitPrice;

    public string? Notes { get; set; }
    public string? Custom { get; set; }

}
