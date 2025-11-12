using System;
using System.ComponentModel.DataAnnotations.Schema;
using BizBuddy.Domain.Common;

namespace BizBuddy.Domain.Entities.CustomFieldDefs;


[Table(nameof(CustomFieldDef), Schema = "CustomFieldDefs")]

public class CustomFieldDef : BaseEntityTenant
{
    public int Id { get; set; }
    public string EntityType { get; set; } // "customer", "product", "order", "appointment", "staff"
    public string Key { get; set; }        // Örn: "skinType"
    public string Label { get; set; }      // Ekranda gözükecek ad: "Cilt Tipi"
    public string DataType { get; set; }   // "text", "number", "date", "datetime", "select", "toggle"

    public bool Required { get; set; }
    public string[]? Options { get; set; }  // select için seçenek listesi
    public int Order { get; set; }

    public bool IsActive { get; set; }
}
