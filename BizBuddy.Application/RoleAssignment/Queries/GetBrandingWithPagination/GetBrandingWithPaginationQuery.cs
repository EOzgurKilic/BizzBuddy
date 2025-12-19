using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.RoleAssignment.Queries.GetBrandingWithPagination;


public record GetBrandingWithPaginationQuery() : IRequest<Result<PaginatedList<BrandingListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetBrandingWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetBrandingWithPaginationQuery, Result<PaginatedList<BrandingListDto>>>
{
    public async Task<Result<PaginatedList<BrandingListDto>>> Handle(GetBrandingWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Branding
       .ProjectTo<BrandingListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<BrandingListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<BrandingListDto>>.Success(result);
    }
}