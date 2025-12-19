using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.Staff.Queries.GetEmployeeWithPagination;

public record GetEmployeeWithPaginationQuery() : IRequest<Result<PaginatedList<EmployeeListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetEmployeeWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetEmployeeWithPaginationQuery, Result<PaginatedList<EmployeeListDto>>>
{
    public async Task<Result<PaginatedList<EmployeeListDto>>> Handle(GetEmployeeWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.Employee
       .ProjectTo<EmployeeListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<EmployeeListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<EmployeeListDto>>.Success(result);
    }
}