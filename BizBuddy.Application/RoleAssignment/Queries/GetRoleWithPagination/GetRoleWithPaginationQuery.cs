using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.RoleAssignment.Queries.GetRoleWithPagination;


public record GetRoleWithPaginationQuery() : IRequest<Result<PaginatedList<RoleListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetRoleWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetRoleWithPaginationQuery, Result<PaginatedList<RoleListDto>>>
{
    public async Task<Result<PaginatedList<RoleListDto>>> Handle(GetRoleWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Role
       .ProjectTo<RoleListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<RoleListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<RoleListDto>>.Success(result);
    }
}