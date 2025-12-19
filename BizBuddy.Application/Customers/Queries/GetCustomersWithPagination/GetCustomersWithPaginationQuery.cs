using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using BizBuddy.Application.Customers.Queries.GetCustomersWithPagination;
using MediatR;

namespace BizBuddy.Application.Customers.Queries.GetCustomersWithPaginationQuery;

public record GetCustomersWithPaginationQuery() : IRequest<Result<PaginatedList<GetCustomerListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetCustomersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetCustomersWithPaginationQuery, Result<PaginatedList<GetCustomerListDto>>>
{
    public async Task<Result<PaginatedList<GetCustomerListDto>>> Handle(GetCustomersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Customer
       .ProjectTo<GetCustomerListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<GetCustomerListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<GetCustomerListDto>>.Success(result);
    }
}