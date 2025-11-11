using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Products;

namespace BizBuddy.Domain.Entities.InventoryMoves;



[Table(nameof(InventoryMove), Schema = "InventoryMoves")]
public class InventoryMove : BaseEntityTenant
{
    public int Id { get; set; }
    public Product Product { get; set; }

    public int ProductId { get; set; }

    public decimal Qty { get; set; }
    public string? Reason { get; set; }

    public string? RefType { get; set; }

    public int? RefId { get; set; }
}
