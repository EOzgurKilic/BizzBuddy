using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Orders.Queries.GetOrderWithPagination;

public record GetOrderWithPaginationQuery() : IRequest<Result<PaginatedList<OrderListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetOrderWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetOrderWithPaginationQuery, Result<PaginatedList<OrderListDto>>>
{
    public async Task<Result<PaginatedList<OrderListDto>>> Handle(GetOrderWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Order
       .ProjectTo<OrderListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<OrderListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<OrderListDto>>.Success(result);
    }
}