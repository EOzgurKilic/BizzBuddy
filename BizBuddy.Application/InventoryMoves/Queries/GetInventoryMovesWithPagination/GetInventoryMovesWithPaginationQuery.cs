using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.InventoryMoves.Queries.GetInventoryMovesWithPagination;

public record GetInventoryMovesWithPaginationQuery() : IRequest<Result<PaginatedList<InventoryMovesListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetInventoryMovesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetInventoryMovesWithPaginationQuery, Result<PaginatedList<InventoryMovesListDto>>>
{
    public async Task<Result<PaginatedList<InventoryMovesListDto>>> Handle(GetInventoryMovesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.InventoryMove
       .ProjectTo<InventoryMovesListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<InventoryMovesListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<InventoryMovesListDto>>.Success(result);
    }
}