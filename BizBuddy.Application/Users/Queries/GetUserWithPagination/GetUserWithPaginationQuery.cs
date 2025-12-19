using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Users.Queries.GetUserWithPagination;


public record GetUserWithPaginationQuery() : IRequest<Result<PaginatedList<UserListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetUserWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetUserWithPaginationQuery, Result<PaginatedList<UserListDto>>>
{
    public async Task<Result<PaginatedList<UserListDto>>> Handle(GetUserWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.User
       .ProjectTo<UserListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<UserListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<UserListDto>>.Success(result);
    }
}