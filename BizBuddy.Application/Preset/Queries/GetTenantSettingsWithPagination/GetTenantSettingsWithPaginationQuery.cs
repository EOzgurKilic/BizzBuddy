using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Preset.Queries.GetTenantSettingsWithPagination;


public record GetTenantSettingsWithPaginationQuery() : IRequest<Result<PaginatedList<TenantSettingsListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetTenantSettingsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetTenantSettingsWithPaginationQuery, Result<PaginatedList<TenantSettingsListDto>>>
{
    public async Task<Result<PaginatedList<TenantSettingsListDto>>> Handle(GetTenantSettingsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.TenantSettings
       .ProjectTo<TenantSettingsListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<TenantSettingsListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<TenantSettingsListDto>>.Success(result);
    }
}