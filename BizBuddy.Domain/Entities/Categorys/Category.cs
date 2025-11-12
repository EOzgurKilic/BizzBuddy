using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;
using BizBuddy.Domain.Entities.Products;

namespace BizBuddy.Domain.Entities.Categorys;



[Table(nameof(Category), Schema = "Categorys")]

public class Category : BaseEntityTenant
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int? ParentId { get; set; }
    public string? Type { get; set; }
    public int? SortOrder { get; set; }
    public Category? Parent { get; set; }

    public ICollection<Product>? Products { get; set; }
}
