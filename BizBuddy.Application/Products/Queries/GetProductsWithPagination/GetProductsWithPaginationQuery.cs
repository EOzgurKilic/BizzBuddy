using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Products.Queries.GetProductsWithPagination;


public record GetProductsWithPaginationQuery() : IRequest<Result<PaginatedList<ProductsListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetProductsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetProductsWithPaginationQuery, Result<PaginatedList<ProductsListDto>>>
{
    public async Task<Result<PaginatedList<ProductsListDto>>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Product
       .ProjectTo<ProductsListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<ProductsListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<ProductsListDto>>.Success(result);
    }
}