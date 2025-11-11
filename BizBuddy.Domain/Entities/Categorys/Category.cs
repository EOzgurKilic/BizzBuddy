using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.Categorys;



[Table(nameof(Category), Schema = "Categorys")]

public class Category:BaseEntityTenant
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public int ParentId { get; set; }

    public string? Type { get; set; }

    public int? sortOrder { get; set; }
}
