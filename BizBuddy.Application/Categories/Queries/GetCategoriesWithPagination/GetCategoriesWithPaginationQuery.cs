using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Categories.Queries.GetCategoriesWithPagination;


public record GetCategoriesWithPaginationQuery() : IRequest<Result<PaginatedList<CategoriesDtoList>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCategoriesWithPaginationQuery, Result<PaginatedList<CategoriesDtoList>>>
{
    public async Task<Result<PaginatedList<CategoriesDtoList>>> Handle(GetCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Category
       .ProjectTo<CategoriesDtoList>(mapper.ConfigurationProvider);

        var result = await PaginatedList<CategoriesDtoList>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<CategoriesDtoList>>.Success(result);
    }
}