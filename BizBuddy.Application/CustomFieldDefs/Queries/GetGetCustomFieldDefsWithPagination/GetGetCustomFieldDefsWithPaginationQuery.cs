using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BizBuddy.Application.Common;
using BizBuddy.Application.Common.Interfaces;
using BizBuddy.Application.Common.Models;
using MediatR;

namespace BizBuddy.Application.CustomFieldDefs.Queries.GetGetCustomFieldDefsWithPagination;

public record GetGetCustomFieldDefsWithPaginationQuery() : IRequest<Result<PaginatedList<CustomFieldDefsListDto>>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 50;
    public string Sort { get; init; } = "Id desc";
}

public class GetGetCustomFieldDefsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetGetCustomFieldDefsWithPaginationQuery, Result<PaginatedList<CustomFieldDefsListDto>>>
{
    public async Task<Result<PaginatedList<CustomFieldDefsListDto>>> Handle(GetGetCustomFieldDefsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = context.CustomFieldDef
       .ProjectTo<CustomFieldDefsListDto>(mapper.ConfigurationProvider);

        var result = await PaginatedList<CustomFieldDefsListDto>.CreateAsync(
            query,
            request.PageNumber,
            request.PageSize);

        return Result<PaginatedList<CustomFieldDefsListDto>>.Success(result);
    }
}