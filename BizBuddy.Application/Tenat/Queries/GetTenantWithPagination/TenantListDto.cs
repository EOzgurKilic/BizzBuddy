using System;
using BizBuddy.Application.Mapping;
using BizBuddy.Domain.Entities.Tenats;

namespace BizBuddy.Application.Tenat.Queries.GetTenantWithPagination;

public class TenantListDto:IMapFrom<Tenantt>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? PresetName { get; set; }
}