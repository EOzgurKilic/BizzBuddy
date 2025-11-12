using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Categories;

namespace BizBuddy.Domain.Entities.Products;


[Table(nameof(Product), Schema = "Products")]
public class Product : BaseEntityTenant
{
   public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string? Sku { get; set; }
    public decimal Price { get; set; }
    public decimal? StockQty { get; set; }
    public string? Unit { get; set; }
    
}
