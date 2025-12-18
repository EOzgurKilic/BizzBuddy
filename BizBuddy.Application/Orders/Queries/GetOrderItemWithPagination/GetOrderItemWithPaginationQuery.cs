using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Orders.Queries.GetOrderItemWithPagination;

public record GetOrderItemWithPaginationQuery() : IRequest<Result<PaginatedList<OrderItemListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetOrderItemWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetOrderItemWithPaginationQuery, Result<PaginatedList<OrderItemListDto>>>
{
    public async Task<Result<PaginatedList<OrderItemListDto>>> Handle(GetOrderItemWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.OrderItem
       .ProjectTo<OrderItemListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<OrderItemListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<OrderItemListDto>>.Success(result);
    }
}