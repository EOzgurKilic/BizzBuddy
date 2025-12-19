using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Tenat.Queries.GetTenantWithPagination;

public record GetTenantWithPaginationQuery() : IRequest<Result<PaginatedList<TenantListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetTenantWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetTenantWithPaginationQuery, Result<PaginatedList<TenantListDto>>>
{
    public async Task<Result<PaginatedList<TenantListDto>>> Handle(GetTenantWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Tenat
       .ProjectTo<TenantListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<TenantListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<TenantListDto>>.Success(result);
    }
}